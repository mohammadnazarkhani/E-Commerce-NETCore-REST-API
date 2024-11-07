using TondForoosh.Api.Data;
using TondForoosh.Api.Dtos;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Mapping;
using TondForoosh.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace TondForoosh.Api.Endpoints
{
    public static class AuthenticationEndpoints
    {
        const string RegisterEndpointName = "RegisterUser";
        const string AuthenticationEndpointGroupName = "Auth";

        public static RouteGroupBuilder MapAuthenticationEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(AuthenticationEndpointGroupName)
                .WithParameterValidation();

            // POST /auth/register
            group.MapPost("/register", async (RegisterUserDto registerUserDto, TondForooshContext dbContext, IAuthService authService, IPasswordHasherService passwordHasher) =>
            {
                // Check if username already exists
                if (await dbContext.Users.AnyAsync(u => u.Username == registerUserDto.Username))
                {
                    return Results.BadRequest("Username is already taken.");
                }

                // Convert DTO to Entity and set default Role as "User"
                User user = registerUserDto.ToEntity();

                // Hash the password before saving to the database
                user.Password = passwordHasher.HashPassword(registerUserDto.Password); // Hashing the password

                // Save the new user to the database
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();

                // Generate JWT token for the newly registered user
                var token = authService.Authenticate(user);

                // Return the response with user details and token
                return Results.CreatedAtRoute(
                    RegisterEndpointName,
                    new { id = user.Id },
                    new { user.Id, user.Username, Token = token }
                );
            }).WithName(RegisterEndpointName);

            return group;
        }
    }
}
