namespace FakeEmailGateway.Models.DTOs;

/// <summary>
/// Data Transfer Object for user login.
/// This DTO is used to encapsulate the necessary information for a user to log in.
/// </summary>
public record class RegisterUserDto
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? PhoneNumber { get; init; }
}
