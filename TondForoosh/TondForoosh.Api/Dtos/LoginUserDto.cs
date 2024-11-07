using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos
{
    public record class LoginUserDto(
        [Required(ErrorMessage = "Username is required.")]
        string Username,

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        string Password
    );
}
