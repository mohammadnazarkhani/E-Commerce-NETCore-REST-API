using System;

namespace FakeEmailGateway.Models;

public class Inbox : Base.EntityBase
{
    // Relations
    public Guid UserId { get; set; }
    public User? User { get; set; }

    // Navigation properties
    public List<Email> ReceivedEmails { get; set; } = new List<Email>();
}
