using System.ComponentModel.DataAnnotations;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Dtos.User
{
    public record class CreateUserDto(

        [Required]
        [StringLength(50, MinimumLength = 3)]
        string Username,

        [Required]
        [StringLength(100, MinimumLength = 6)] // Ensure password has minimum length
        string Password,

        [Required]
        UserRole Role
    );
}
