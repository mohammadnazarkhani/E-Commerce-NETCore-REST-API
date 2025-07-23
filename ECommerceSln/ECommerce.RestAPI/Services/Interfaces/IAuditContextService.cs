using System;

namespace ECommerce.RestAPI.Services.Interfaces;

/// <summary>
/// Interface for managing audit context and user information
/// </summary>
public interface IAuditContextService
{
    /// <summary>
    /// Gets the current user ID
    /// </summary>
    Guid? GetCurrentUserId();

    /// <summary>
    /// Gets the current username
    /// </summary>
    string? GetCurrentUserName();

    /// <summary>
    /// Gets the current user's IP address
    /// </summary>
    string? GetCurrentUserIpAddress();

    /// <summary>
    /// Gets the current user's user agent
    /// </summary>
    string? GetCurrentUserAgent();

    /// <summary>
    /// Sets additional audit information
    /// </summary>
    void SetAdditionalInfo(string info);

    /// <summary>
    /// Gets additional audit information
    /// </summary>
    string? GetAdditionalInfo();
}
