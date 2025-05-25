using System;

namespace MockSmsProvider.Models;

/// <summary>
/// Sms entity representing each message that will be received by receiver user's inbox.
/// </summary>
public class Sms
{
    public required Guid Id { get; set; }
    public required string Message { get; set; }

    // Relations
    public Guid InboxId { get; set; }
    public Inbox? Inbox { get; set; }

    public required string SenderId { get; set; }
    public User? Sender { get; set; }
}
