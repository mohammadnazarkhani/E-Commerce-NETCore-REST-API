using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
    }
}
