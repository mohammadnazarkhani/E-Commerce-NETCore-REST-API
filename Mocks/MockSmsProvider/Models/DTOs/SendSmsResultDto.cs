namespace MockSmsProvider.Models.DTOs;

public record class SendSmsResultDto
{
    public required bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}
