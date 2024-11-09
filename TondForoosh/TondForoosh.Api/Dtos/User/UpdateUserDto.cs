using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Dtos.User
{
    public class UpdateUserDto
    {
        public string Username { get; set; }
        public UserRole Role { get; set; }
    }
}
