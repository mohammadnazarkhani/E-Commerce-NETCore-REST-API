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

        // Updates User entity with values from UpdateUserDto
        public static User UpdateEntity(this User user, UpdateUserDto userDto)
        {
            user.Username = userDto.Username;
            user.Role = userDto.Role;
            return user;
        }

        // Maps User entity to UserDto for returning user data
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
            };
        }

        // Maps User entity to AuthenticateUserDto for authentication
        public static LoginUserDto ToAuthenticateDto(this User user)
        {
            return new AuthenticateUserDto
            {
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}
