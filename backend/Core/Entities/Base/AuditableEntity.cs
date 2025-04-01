using System;
using Core.Entities.Enums;
using Core.Entities.Interfaces;

namespace Core.Entities.Base;

public class AuditableEntity<TId> : EntityBase<TId>, IAuditableEntity, IEntityState
{

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public EntityStatus Status { get; private set; } = EntityStatus.Unchanged;
    public void SetStatus(EntityStatus status)
    {
        Status = status;
    }
}
