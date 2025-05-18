using System;

namespace MockSmsProvider.Models;

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
