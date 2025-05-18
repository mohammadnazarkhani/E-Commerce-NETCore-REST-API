using System;

namespace MockSmsProvider.Models;

public class Inbox
{
    public required Guid Id { get; set; }

    // Relations
    public required string UserId { get; set; }
    public User? User { get; set; }

    public List<Sms> Messages { get; set; } = new List<Sms>();
}
