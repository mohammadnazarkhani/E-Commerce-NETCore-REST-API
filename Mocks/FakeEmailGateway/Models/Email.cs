using System;
using System.ComponentModel.DataAnnotations;

namespace FakeEmailGateway.Models;

public class Email : Base.EntityBase
{
    public string? Subject { get; set; }
    [Required(ErrorMessage = "Body is required.")]
    public required string Body { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    // Relations
    public Outbox? SenderOutbox { get; set; }
    public Guid? SenderOutboxId { get; set; }

    public Inbox? ReceiverInbox { get; set; }
    public Guid? ReceiverInboxId { get; set; }
}
