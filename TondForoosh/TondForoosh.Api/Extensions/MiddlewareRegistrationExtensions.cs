using Microsoft.AspNetCore.Builder;

namespace TondForoosh.Api.Extensions
{
    public static class MiddlewareRegistrationExtensions
    {
        // Configure middlewares
        public static void UseApplicationMiddlewares(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
