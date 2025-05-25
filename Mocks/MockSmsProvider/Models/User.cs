using System;
using System.ComponentModel.DataAnnotations;

namespace MockSmsProvider.Models;

/// <summary>
/// User entity representing the users which will be identified with phone number/company name.
/// </summary>
public class User
{
    /// <summary>
    /// Id property which represents user's phone number or company name
    /// </summary>
    public required string Id { get; set; }

    // Relations
    public Inbox? Inbox { get; set; }

    public List<Sms> SentMessages { get; set; } = new List<Sms>();
}
