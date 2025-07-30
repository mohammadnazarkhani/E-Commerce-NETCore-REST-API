using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ECommerce.RestAPI.Entities.Enums;
using ECommerce.RestAPI.Entities.Interfaces;

namespace ECommerce.RestAPI.Entities.Audit;

/// <summary>
/// Represents an audit trail entry for tracking changes to entiteis
/// </summary>
public class AuditTrail : IEntity
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string EntityName { get; set; } = string.Empty;

    [Required]
    public Guid EntityId { get; set; }

    [Required]
    public AuditAction Action { get; set; } // Enum: INSERT, UPDATE, DELETE

    public string? OldValues { get; set; } // JSON string of old values
    public string? NewValues { get; set; } // JSON string of new values
    public string? ChangedProperties { get; set; } // JSON array of changed property names

    [Required]
    public Guid UserId { get; set; }

    [MaxLength(100)]
    public string? UserName { get; set; }

    [MaxLength(45)]
    public string? IpAddress { get; set; }

    [MaxLength(500)]
    public string? UserAgent { get; set; }

    [Required]
    public DateTime Timestamp { get; set; }

    [MaxLength(500)]
    public string? Reason { get; set; } // Optional reason for the change

    public AuditSource? Source { get; set; } // Enum: API, Web, Mobile, etc.

    public TimeSpan? Duration { get; set; } // Time taken for the opration

    [MaxLength(50)]
    public string? TransactionId { get; set; } // For grouping related changes

    // Navigation properties
    public virtual User User { get; set; } = null!;
}
