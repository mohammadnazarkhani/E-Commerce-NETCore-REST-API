namespace FakeEmailGateway.Models.DTOs;

/// <summary>
/// DTO for displaying email list items (inbox/outbox)
/// </summary>
public class EmailListDto
{
    public Guid Id { get; set; }
    public string SenderEmail { get; set; } = string.Empty;
    public string ReceiverEmail { get; set; } = string.Empty;
    public string? Subject { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsRead { get; set; }
}