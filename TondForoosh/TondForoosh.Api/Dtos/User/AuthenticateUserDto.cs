using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos.User
{
    public record class AuthenticateUserDto(

        [Required]
        [StringLength(50, MinimumLength = 3)]
        string Username,

        [Required]
        [StringLength(100, MinimumLength = 6)] // Ensure password has minimum length
        string Password
    );
}
