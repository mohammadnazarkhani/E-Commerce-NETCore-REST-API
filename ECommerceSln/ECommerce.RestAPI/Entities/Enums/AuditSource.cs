namespace ECommerce.RestAPI.Entities.Enums;

/// <summary>
/// Source of the opration that trigerred the audit trail entry.
/// </summary>
public enum AuditSource
{
    API = 0,
    Web = 1,
    Mobile = 2,
    BackgroundJob = 3,
    AdminPanel = 4,
    Other = 5 // For any other sources not explicitly defined
}
