using TondForoosh.Api.Dtos.User;
using TondForoosh.Api.Entities;

namespace TondForoosh.Api.Mapping
{
    public static class UserMapping
    {
        // Maps CreateUserDto to User entity
        public static User ToEntity(this CreateUserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Role = userDto.Role
            };
        }

        // Maps RegisterUserDto to User entity
        public static User ToEntity(this RegisterUserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password,
                Role = UserRole.User // Default role for new registrations
            };
        }

        // Maps UpdateUserDto to existing User entity
        public static User UpdateEntity(this User user, UpdateUserDto userDto)
        {
            user.Username = userDto.Username;
            user.Role = userDto.Role;
            return user;
        }

        // Maps User entity to UserDto for returning user data
        public static UserDto ToDto(this User user)
        {
            return new UserDto(
                user.Id,
                user.Username,
                user.Role ?? UserRole.User
            );
        }

        // Maps LoginUserDto to User entity (Only username and password needed)
        public static User ToEntity(this LoginUserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password
            };
        }
    }
}
