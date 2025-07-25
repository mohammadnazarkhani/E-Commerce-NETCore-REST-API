using System;

namespace ECommerce.RestAPI.Entities.Interfaces;

/// <summary>
/// Extended auditable entity interface with user tracking
/// </summary>
public interface IFullAuditableEntity : IAuditableEntity
{
    /// <summary>
    /// ID of the user who created the entity
    /// </summary>
    Guid? CreatedBy { get; set; }

    /// <summary>
    /// ID of the user who last modified the entity
    /// </summary>
    Guid? LastModifiedBy { get; set; }

    /// <summary>
    /// Soft delete flag
    /// </summary>
    bool IsDeleted { get; set; }

    /// <summary>
    /// Soft delete timestamp
    /// </summary>
    DateTime? DeletedAt { get; set; }

    /// <summary>
    /// ID of the user who deleted the entity
    /// </summary>
    Guid? DeletedBy { get; set; }
}
