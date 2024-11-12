using TondForoosh.Api.Endpoints;

namespace TondForoosh.Api.Extensions
{
    public static class EndpointRegistrationExtensions
    {
        // Use WebApplication as the receiver to map the endpoints
        public static void MapApplicationEndpoints(this WebApplication app)
        {
            // Here we call the MapAuthenticationEndpoints directly on app (WebApplication)
            app.MapAuthenticationEndpoints();
            app.MapCategoryEndpoints();
            app.MapProductEndpoints();
            app.MapUserEndpoints();
        }
    }
}
