using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;
using ECommerce.RestAPI.Entities.Base;

namespace ECommerce.RestAPI.Entities.Audit;

/// <summary>
/// Represents an audit log entry for tracking entity changes
/// </summary>
public class AuditLog : AuditableEntityBase
{
    [Required]
    [MaxLength(100)]
    public string EntityName { get; set; } = string.Empty;

    [Required]
    public Guid EntityId { get; set; }

    [Required]
    public AuditAction Action { get; set; }

    [Required]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public Guid? UserId { get; set; }

    [MaxLength(100)]
    public string? UserName { get; set; }

    [MaxLength(45)]
    public string? IpAddress { get; set; }

    [MaxLength(500)]
    public string? UserAgent { get; set; }

    // JSON serialized old values
    public string? OldValues { get; set; }

    // JOSN serialized new values
    public string? NewValues { get; set; }

    // JSON serialized changed properties
    public string? ChangedProperties { get; set; }

    [MaxLength(1000)]
    public string? AuditionalInfo { get; set; }

    // Navigation property
    public User? User { get; set; }
}
