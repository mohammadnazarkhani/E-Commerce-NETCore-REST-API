using System;

namespace Core.Entities.Interfaces;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}
