namespace ECommerce.RestAPI.Entities.Enums;

/// <summary>
/// Represents the type of audit action performed
/// </summary>
public enum AuditAction
{
    Create = 1,
    Update = 2,
    Delete = 3,
    Read = 4,
    Login = 5,
    Logout = 6,
    PasswordChange = 7,
    PermissionChange = 8
}
