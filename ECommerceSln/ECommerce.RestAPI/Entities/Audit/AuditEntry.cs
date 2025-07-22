using System;
using ECommerce.RestAPI.Entities.Enums;

namespace ECommerce.RestAPI.Entities.Audit;

/// <summary>
/// Represents a detailed audit entry with change information
/// </summary>
public class AuditEntry
{
    public string EntityName { get; set; } = string.Empty;
    public Guid EntityId { get; set; }
    public AuditAction Action { get; set; }
    public Dictionary<string, object?> OldValues { get; set; } = new();
    public Dictionary<string, object?> NewValues { get; set; } = new();
    public List<string> ChangedProperties { get; set; } = new();
    public string? AdditionalInfo { get; set; }
}
