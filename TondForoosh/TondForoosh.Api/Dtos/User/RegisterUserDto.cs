using System.ComponentModel.DataAnnotations;

namespace TondForoosh.Api.Dtos.User
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)] // Ensure password has minimum length
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)] // Ensure confirmation password matches the main password
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // Constructor to populate the members
        public RegisterUserDto(string username, string password, string confirmPassword)
        {
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
