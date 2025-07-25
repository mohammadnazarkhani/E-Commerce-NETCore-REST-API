using System;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Entities.Base;

/// <summary>
/// Extended base class for fully auditable entities
/// </summary>
public class FullAuditableEntityBase : AuditableEntityBase, IFullAuditableEntity
{
    public Guid? CreatedBy { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }

    // Navigation properties
    public User? CreatedByUser { get; set; }
    public User? LastModifiedByUser { get; set; }
    public User? DeletedByUser { get; set; }
}