using System;

namespace FakeEmailGateway.Models;

public class Outbox : Base.EntityBase
{
    // Relations
    public Guid UserId { get; set; }
    public User? User { get; set; }

    // Navigation properties
    public List<Email> SentEmails { get; set; }
}
