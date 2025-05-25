using System;

namespace MockSmsProvider.Models;

/// <summary>
/// Inbox entity representing users message inbox containinig all user's received messages.
/// </summary>
public class Inbox
{
    public required Guid Id { get; set; }

    // Relations
    public required string UserId { get; set; }
    public User? User { get; set; }

    public List<Sms> Messages { get; set; } = new List<Sms>();
}
