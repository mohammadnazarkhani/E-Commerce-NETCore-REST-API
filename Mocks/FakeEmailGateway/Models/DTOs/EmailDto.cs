namespace FakeEmailGateway.Models.DTOs;

/// <summary>
/// DTO for displaying email information
/// </summary>
public class EmailDto
{
    public Guid Id { get; set; }
    public string SenderEmail { get; set; } = string.Empty;
    public string SenderName { get; set; } = string.Empty;
    public string ReceiverEmail { get; set; } = string.Empty;
    public string ReceiverName { get; set; } = string.Empty;
    public string? Subject { get; set; }
    public string Body { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
}