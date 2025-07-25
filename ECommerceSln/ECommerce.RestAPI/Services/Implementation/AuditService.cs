using System;
using System.Text.Json;
using ECommerce.RestAPI.Data.UnitOfWork;
using ECommerce.RestAPI.Entities.Audit;
using ECommerce.RestAPI.Entities.Enums;
using ECommerce.RestAPI.Entities.Interfaces;
using ECommerce.RestAPI.Services.Interfaces;

namespace ECommerce.RestAPI.Services.Implementation;

  /// <summary>
    /// Implementation of audit service for logging entity changes
    /// </summary>
    public class AuditService : IAuditService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditContextService _auditContextService;

        public AuditService(IUnitOfWork unitOfWork, IAuditContextService auditContextService)
        {
            _unitOfWork = unitOfWork;
            _auditContextService = auditContextService;
        }

        public async Task<AuditLog> CreateAuditLogAsync<TEntity>(
            TEntity entity,
            AuditAction action,
            AuditEntry? auditEntry = null,
            CancellationToken cancellationToken = default
        ) where TEntity : class, IEntity
        {
            auditEntry ??= CreateAuditEntry(entity, action);

            var auditLog = new AuditLog
            {
                EntityName = auditEntry.EntityName,
                EntityId = auditEntry.EntityId,
                Action = auditEntry.Action,
                UserId = _auditContextService.GetCurrentUserId(),
                UserName = _auditContextService.GetCurrentUserName(),
                IpAddress = _auditContextService.GetCurrentUserIpAddress(),
                UserAgent = _auditContextService.GetCurrentUserAgent(),
                OldValues = auditEntry.OldValues.Any() ? JsonSerializer.Serialize(auditEntry.OldValues) : null,
                NewValues = auditEntry.NewValues.Any() ? JsonSerializer.Serialize(auditEntry.NewValues) : null,
                ChangedProperties = auditEntry.ChangedProperties.Any() ? JsonSerializer.Serialize(auditEntry.ChangedProperties) : null,
                AdditionalInfo = auditEntry.AdditionalInfo ?? _auditContextService.GetAdditionalInfo()
            };

            var auditRepository = _unitOfWork.GetRepository<AuditLog>();
            await auditRepository.AddAsync(auditLog, cancellationToken);
            
            return auditLog;
        }

        public async Task CreateAuditLogsAsync(
            IEnumerable<AuditEntry> auditEntries,
            CancellationToken cancellationToken = default
        )
        {
            var auditLogs = auditEntries.Select(entry => new AuditLog
            {
                EntityName = entry.EntityName,
                EntityId = entry.EntityId,
                Action = entry.Action,
                UserId = _auditContextService.GetCurrentUserId(),
                UserName = _auditContextService.GetCurrentUserName(),
                IpAddress = _auditContextService.GetCurrentUserIpAddress(),
                UserAgent = _auditContextService.GetCurrentUserAgent(),
                OldValues = entry.OldValues.Any() ? JsonSerializer.Serialize(entry.OldValues) : null,
                NewValues = entry.NewValues.Any() ? JsonSerializer.Serialize(entry.NewValues) : null,
                ChangedProperties = entry.ChangedProperties.Any() ? JsonSerializer.Serialize(entry.ChangedProperties) : null,
                AdditionalInfo = entry.AdditionalInfo ?? _auditContextService.GetAdditionalInfo()
            });

            var auditRepository = _unitOfWork.GetRepository<AuditLog>();
            await auditRepository.AddRangeAsync(auditLogs, cancellationToken);
        }

        public async Task<IEnumerable<AuditLog>> GetEntityAuditLogsAsync(
            string entityName,
            Guid entityId,
            CancellationToken cancellationToken = default
        )
        {
            var auditRepository = _unitOfWork.GetRepository<AuditLog>();
            return await auditRepository.FindAsync(
                a => a.EntityName == entityName && a.EntityId == entityId,
                new[] { nameof(AuditLog.User) },
                cancellationToken
            );
        }

        public async Task<IEnumerable<AuditLog>> GetUserAuditLogsAsync(
            Guid userId,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            CancellationToken cancellationToken = default
        )
        {
            var auditRepository = _unitOfWork.GetRepository<AuditLog>();
            return await auditRepository.FindAsync(
                a => a.UserId == userId &&
                     (fromDate == null || a.Timestamp >= fromDate) &&
                     (toDate == null || a.Timestamp <= toDate),
                new[] { nameof(AuditLog.User) },
                cancellationToken
            );
        }

        public async Task<(IEnumerable<AuditLog> Data, int TotalCount)> GetAuditLogsPagedAsync(
            int pageNumber,
            int pageSize,
            string? entityName = null,
            AuditAction? action = null,
            Guid? userId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            CancellationToken cancellationToken = default
        )
        {
            var auditRepository = _unitOfWork.GetRepository<AuditLog>();
            return await auditRepository.GetPagedAsync(
                pageNumber,
                pageSize,
                predicate: a => (entityName == null || a.EntityName == entityName) &&
                               (action == null || a.Action == action) &&
                               (userId == null || a.UserId == userId) &&
                               (fromDate == null || a.Timestamp >= fromDate) &&
                               (toDate == null || a.Timestamp <= toDate),
                orderBy: q => q.OrderByDescending(a => a.Timestamp),
                includeProperties: new[] { nameof(AuditLog.User) },
                cancellationToken: cancellationToken
            );
        }

        public AuditEntry CreateAuditEntry<TEntity>(
            TEntity entity,
            AuditAction action,
            Dictionary<string, object?>? oldValues = null,
            Dictionary<string, object?>? newValues = null
        ) where TEntity : class, IEntity
        {
            var entry = new AuditEntry
            {
                EntityName = typeof(TEntity).Name,
                EntityId = entity.Id,
                Action = action
            };

            if (oldValues != null)
                entry.OldValues = oldValues;

            if (newValues != null)
                entry.NewValues = newValues;

            if (oldValues != null && newValues != null)
            {
                entry.ChangedProperties = newValues.Keys
                    .Where(key => !Equals(oldValues.GetValueOrDefault(key), newValues[key]))
                    .ToList();
            }

            return entry;
        }
    }