using TondForoosh.Api.Dtos;
using TondForoosh.Api.Services;
using TondForoosh.Api.Data;
using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Mapping;

namespace TondForoosh.Api.Endpoints
{
    public static class AuthenticationEndpoints
    {
        const string RegisterEndpointName = "RegisterUser";
        const string LoginEndpointName = "LoginUser";
        const string AuthenticationEndpointGroupName = "Auth";

        public static RouteGroupBuilder MapAuthenticationEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(AuthenticationEndpointGroupName)
                .WithParameterValidation();

            // POST /auth/register (for user registration)
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
                user.Password = passwordHasher.HashPassword(registerUserDto.Password);

                // Save the new user to the database
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();

                // Generate JWT token for the newly registered user
                var token = authService.GenerateTokenForNewUser(user);

                // Return the response with user details and token
                return Results.CreatedAtRoute(
                    RegisterEndpointName,
                    new { id = user.Id },
                    new { user.Id, user.Username, Token = token }
                );
            }).WithName(RegisterEndpointName);

            // POST /auth/login (for user login)
            group.MapPost("/login", async (LoginUserDto loginUserDto, IAuthService authService) =>
            {
                // Use the Authenticate method to verify the user and generate a token
                var token = authService.Authenticate(loginUserDto.Username, loginUserDto.Password);

                if (token == null)
                {
                    return Results.Unauthorized();
                }

                // Return the generated token in the response
                return Results.Ok(new { Token = token });
            }).WithName(LoginEndpointName);

            return group;
        }
    }
}
