using System;
using ECommerce.RestAPI.Entities.Enums;

namespace ECommerce.RestAPI.Services.Audit.Interfaces;

/// <summary>
/// Provides an interface for the audit context.
/// This interface can be implemented to provide custom audit logging functionality.
/// </summary>
public interface IAuditContext
{
    Guid UserId { get; set; }
    string? UserName { get; set; }
    string? IpAddress { get; set; }
    string? UserAgent { get; set; }
    AuditSource? Source { get; set; }
    string? TransactionId { get; set; }
    string? Reason { get; set; }
    DateTime Timestamp { get; set; }
}
