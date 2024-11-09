using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Dtos.User
{
    public class CreateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
