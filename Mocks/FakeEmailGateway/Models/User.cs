using System;
using System.ComponentModel.DataAnnotations;

namespace FakeEmailGateway.Models;

public class User : Base.EntityBase
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public required string EmailAddress { get; set; }
    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    // Navigation properties
    public Outbox? Outbox { get; set; }
    public Inbox? Inbox { get; set; }
}
