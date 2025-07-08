using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce.RestAPI.Data
{
    public static class DataExtensions
    {
        /// <summary>
        /// Applies any pending migrations and updates the database at application startup.
        /// </summary>
        public static IHost MigrateAndSeedDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
                db.Database.Migrate();
            }
            return host;
        }
    }
}
