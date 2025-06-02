using System;
using System.ComponentModel.DataAnnotations;

namespace FakeEmailGateway.Models;

public class Email : Base.EntityBase
{
    public string? Subject { get; set; }
    [Required(ErrorMessage = "Body is required.")]
    public required string Body { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
}
