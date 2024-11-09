using TondForoosh.Api.Dtos;
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
                // Use the AuthenticationHandler to handle the registration logic
                var result = await authHandler.HandleRegisterAsync(registerUserDto);

                // Return the result directly as it is already handled in the handler
                return result;  // This could be CreatedAtRoute or BadRequest as per the result from HandleRegisterAsync
            }).WithName(RegisterEndpointName);

            // POST /auth/login (for user login)
            group.MapPost("/login", async (LoginUserDto loginUserDto, AuthenticationHandler authHandler) =>
            {
                // Use the AuthenticationHandler to handle the login logic
                var result = authHandler.HandleLogin(loginUserDto);

                // Return the result directly as it is already handled in the handler
                return result;  // This could be Ok or Unauthorized as per the result from HandleLogin
            }).WithName(LoginEndpointName);

            return group;
        }
    }
}
