using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ECommerce.RestAPI.Entities.Interfaces;
using ECommerce.RestAPI.Services.Interfaces;
using ECommerce.RestAPI.Entities.Enums;

namespace ECommerce.RestAPI.Data.Interceptors;

/// <summary>
/// EF Core interceptor for automatic audit logging
/// </summary>
public class AuditInterceptor : SaveChangesInterceptor
{
    private readonly IAuditContextService _auditContextService;
    private readonly IAuditService _auditService;

    public AuditInterceptor(
        IAuditContextService auditContextService,
        IAuditService auditService)
    {
        _auditContextService = auditContextService;
        _auditService = auditService;
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            await HandleAuditAsync(eventData.Context, cancellationToken);
        }

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
        {
            HandleAuditAsync(eventData.Context, CancellationToken.None).GetAwaiter().GetResult();
        }

        return base.SavingChanges(eventData, result);
    }

    private async Task HandleAuditAsync(DbContext context, CancellationToken cancellationToken)
    {
        var userId = _auditContextService.GetCurrentUserId();
        var now = DateTime.UtcNow;

        var auditEntries = new List<Entities.Audit.AuditEntry>();

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.Entity is not IEntity entity) continue;

            // Handle auditable entities
            if (entry.Entity is IAuditableEntity auditableEntity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        auditableEntity.CreatedAt = now;
                        if (auditableEntity is IFullAuditableEntity fullAuditable)
                        {
                            fullAuditable.CreatedBy = userId;
                        }
                        break;

                    case EntityState.Modified:
                        auditableEntity.LastModifiedAt = now;
                        if (auditableEntity is IFullAuditableEntity fullAuditableModified)
                        {
                            fullAuditableModified.LastModifiedBy = userId;
                        }
                        break;
                }
            }

            // Create audit entries
            var auditEntry = CreateAuditEntry(entry);
            if (auditEntry != null)
            {
                auditEntries.Add(auditEntry);
            }
        }

        if (auditEntries.Any())
        {
            await _auditService.CreateAuditLogsAsync(auditEntries, cancellationToken);
        }
    }

    private Entities.Audit.AuditEntry? CreateAuditEntry(EntityEntry entry)
    {
        if (entry.Entity is not IEntity entity) return null;

        var auditEntry = new Entities.Audit.AuditEntry
        {
            EntityName = entry.Entity.GetType().Name,
            EntityId = entity.Id
        };

        switch (entry.State)
        {
            case EntityState.Added:
                auditEntry.Action = AuditAction.Create;
                auditEntry.NewValues = GetEntityValues(entry);
                break;

            case EntityState.Modified:
                auditEntry.Action = AuditAction.Update;
                auditEntry.OldValues = GetOriginalValues(entry);
                auditEntry.NewValues = GetEntityValues(entry);
                auditEntry.ChangedProperties = entry.Properties
                    .Where(p => p.IsModified)
                    .Select(p => p.Metadata.Name)
                    .ToList();
                break;

            case EntityState.Deleted:
                auditEntry.Action = AuditAction.Delete;
                auditEntry.OldValues = GetEntityValues(entry);
                break;

            default:
                return null;
        }

        return auditEntry;
    }

    private Dictionary<string, object?> GetEntityValues(EntityEntry entry)
    {
        return entry.Properties.ToDictionary(
            p => p.Metadata.Name,
            p => p.CurrentValue
        );
    }

    private Dictionary<string, object?> GetOriginalValues(EntityEntry entry)
    {
        return entry.Properties.ToDictionary(
            p => p.Metadata.Name,
            p => p.OriginalValue
        );
    }
}