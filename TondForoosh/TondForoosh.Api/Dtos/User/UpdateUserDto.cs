using System.ComponentModel.DataAnnotations;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Dtos.User
{
    public record class UpdateUserDto(

        [Required]
        [StringLength(50, MinimumLength = 3)]
        string Username,

        [Required]
        UserRole Role
    );
}
