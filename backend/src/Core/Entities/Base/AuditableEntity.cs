using System;
using Core.Entities.Enums;
using Core.Entities.Interfaces;

namespace Core.Entities.Base;

public class AuditableEntity<TId> : EntityBase<TId>, IAuditableEntity, IEntityState
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public EntityStatus Status { get; private set; } = EntityStatus.Unchanged;
    public void SetStatus(EntityStatus status)
    {
        Status = status;
    }

    public virtual void OnSaving()
    {
        if (Status == EntityStatus.Added)
        {
            CreatedAt = DateTime.UtcNow;
        }
        else if (Status == EntityStatus.Modified)
        {
            UpdatedAt = DateTime.UtcNow;
        }
        else if (Status == EntityStatus.Deleted)
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }
    }

    public virtual void OnSaved()
    {
        Status = EntityStatus.Unchanged;
    }
}
