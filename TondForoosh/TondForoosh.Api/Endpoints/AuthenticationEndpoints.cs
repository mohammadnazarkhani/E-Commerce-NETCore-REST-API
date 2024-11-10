using TondForoosh.Api.Dtos.User;
using TondForoosh.Api.Endpoints.Handlers;

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
            group.MapPost("/register", async (RegisterUserDto registerUserDto, AuthenticationHandler authHandler) =>
            {
                // Calls the registration handler and returns the result (created or bad request)
                var result = await authHandler.HandleRegisterAsync(registerUserDto);
                return result;
            }).WithName(RegisterEndpointName);

            // POST /auth/login (for user login)
            group.MapPost("/login", (LoginUserDto loginUserDto, AuthenticationHandler authHandler) =>
            {
                // Calls the login handler and returns the result (ok or unauthorized)
                var result = authHandler.HandleLogin(loginUserDto);
                return result;
            }).WithName(LoginEndpointName);

            return group;
        }
    }
}
