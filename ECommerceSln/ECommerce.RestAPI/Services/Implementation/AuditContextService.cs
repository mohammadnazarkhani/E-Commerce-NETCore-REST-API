using System;
using System.Security.Claims;
using ECommerce.RestAPI.Services.Interfaces;

namespace ECommerce.RestAPI.Services.Implementation;

/// <summary>
/// Implementation of IAuditContextService for managing audit context and user information
/// </summary>
public class AuditContextService : IAuditContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private string? _additionalInfo;

    public AuditContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? GetCurrentUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(userIdClaim, out var userId) ? userId : null;
    }

    public string? GetCurrentUserName()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
    }

    public string? GetCurrentUserIpAddress()
    {
        var context = _httpContextAccessor.HttpContext;
        if (context == null) return null;

        // Handle forwarded headers
        var forwarded = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if (!string.IsNullOrEmpty(forwarded))
        {
            return forwarded.Split(',')[0].Trim();
        }

        return context.Connection.RemoteIpAddress?.ToString();
    }

    public string? GetCurrentUserAgent()
    {
        return _httpContextAccessor.HttpContext?.Request?.Headers["User-Agent"].FirstOrDefault();
    }

    public void SetAdditionalInfo(string info)
    {
        _additionalInfo = info;
    }

    public string? GetAdditionalInfo()
    {
        return _additionalInfo;
    }
}
