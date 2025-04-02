using System;
using Core.Entities.Enums;
using Core.Entities.Interfaces;

namespace Core.Entities.Base;

/// <summary>
/// Base class for file-based entities providing common properties for file management
/// </summary>
public class BaseFileEntity : EntityBase<Guid>, IEntityState
{
    /// <summary>
    /// Display name of the file
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// MIME type of the file
    /// </summary>
    public string ContentType { get; set; } = string.Empty;

    /// <summary>
    /// Size of the file in bytes
    /// </summary>
    public long FileSize { get; set; }

    /// <summary>
    /// UTC timestamp when the entity was created
    /// </summary>
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    /// <summary>
    /// UTC timestamp when the entity was last updated
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Current status of the entity, indicating whether it has changed.
    /// </summary>
    public EntityStatus Status { get; private set; } = EntityStatus.Unchanged;

    /// <summary>
    /// Updates the status of the entity.
    /// </summary>
    /// <param name="status">The new status to assign to the entity.</param>
    public void SetStatus(EntityStatus status)
    {
        Status = status;
    }
}
