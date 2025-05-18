using System;
using System.ComponentModel.DataAnnotations;

namespace MockSmsProvider.Models;

public class User
{
    public required string Id { get; set; }

    // Relations
    public Inbox? Inbox { get; set; }

    public List<Sms> SentMessages { get; set; } = new List<Sms>();
}
