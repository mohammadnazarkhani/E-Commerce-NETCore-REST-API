namespace FakeEmailGateway.Models.DTOs;

/// <summary>
/// DTO for sending a new email
/// </summary>
public class SendEmailDto
{
    public required string SenderEmail { get; set; }
    public required string ReceiverEmail { get; set; }
    public string? Subject { get; set; }
    public required string Body { get; set; }
}