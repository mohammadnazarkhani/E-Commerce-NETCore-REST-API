using System;
using ECommerce.RestAPI.Entities.Audit;
using ECommerce.RestAPI.Entities.Enums;
using ECommerce.RestAPI.Entities.Interfaces;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ECommerce.RestAPI.Services.Interfaces;

/// <summary>
/// Interface for audit logging service
/// </summary>
public interface IAuditService
{
    /// <summary>
    /// Creates an audit log entry
    /// </summary>
    Task<AuditLog> CreateAuditLogAsync<TEntity>(
        TEntity entity,
        AuditAction action,
        AuditEntry? auditEntry = null,
        CancellationToken cancellationToken = default
    ) where TEntity : class, IEntity;

    /// <summary>
    /// Creates multiple audit log entries
    Task CreateAuditLogsAsync(
        IEnumerable<AuditEntry> auditEntries,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets audit logs for a specific entity
    /// </summary>
    Task<IEnumerable<AuditLog>> GetEntityAuditLogsAsync(
        string entityName,
        Guid entityId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets audit logs for a specific user
    /// </summary>
    Task<IEnumerable<AuditLog>> GetUserAuditLogsAsync(
        Guid userId,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets audit logs with pagination
    /// </summary>
    Task<(IEnumerable<AuditLog> Data, int TotalCount)> GetAuditLogsPagedAsync(
        int pageNumber,
        int pageSize,
        string? entityName = null,
        AuditAction? action = null,
        Guid? userId = null,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates audit entry from entity chagnes
    /// </summary>
    AuditEntry CreateAuditEntry<TEntity>(
        TEntity entity,
        AuditAction action,
        Dictionary<string, object?>? oldValues = null,
        Dictionary<string, object?>? newValues = null
    ) where TEntity : class, IEntity;
}
