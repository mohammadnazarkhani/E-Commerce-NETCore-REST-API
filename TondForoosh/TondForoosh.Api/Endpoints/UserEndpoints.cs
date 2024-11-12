using Microsoft.AspNetCore.Authorization;
using TondForoosh.Api.Dtos.User;
using TondForoosh.Api.Endpoints.Handlers;

namespace TondForoosh.Api.Endpoints
{
    public static class UserEndpoints
    {
        private const string UserEndpointGroupName = "Users";

        public static RouteGroupBuilder MapUserEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/users")
                .WithTags(UserEndpointGroupName)
                .WithParameterValidation();

            // GET /users - Only Admins can access
            group.MapGet("/", [Authorize(Policy = "AdminOnly")] async (UserEndpointsHandler handler) =>
                await handler.GetAllUsersAsync());

            // GET /users/profile - Only the user themselves can access their profile
            group.MapGet("/profile", [Authorize(Policy = "UserOnly")] async (UserEndpointsHandler handler) =>
                await handler.GetUserProfileAsync());

            // POST /users - Only Admins can create new users
            group.MapPost("/", [Authorize(Policy = "AdminOnly")] async (CreateUserDto dto, UserEndpointsHandler handler) =>
                await handler.CreateUserAsync(dto));

            // PUT /users/{id} - Only Admins can update user details
            group.MapPut("/{id}", [Authorize(Policy = "AdminOnly")] async (int id, UpdateUserDto dto, UserEndpointsHandler handler) =>
                await handler.UpdateUserAsync(id, dto));

            // DELETE /users/{id} - Only Admins can delete users
            group.MapDelete("/{id}", [Authorize(Policy = "AdminOnly")] async (int id, UserEndpointsHandler handler) =>
                await handler.DeleteUserAsync(id));

            return group;
        }
    }
}
