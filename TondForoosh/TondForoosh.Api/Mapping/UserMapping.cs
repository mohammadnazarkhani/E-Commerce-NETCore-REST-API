using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    public static class UserMapping
    {
        // Extension method to map RegisterUserDto to User entity
        public static User ToEntity(this RegisterUserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Role = UserRole.User // Default role is "User" during registration
            };
        }
    }
}
