using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TondForooshApi.Models;
using Microsoft.Extensions.Configuration;

namespace TondForooshApi.Services;

public static class ServiceRegistrationExtensions
{
    #region API Services
    public static void RegisterApiServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
        services.AddControllers();
    }

    public static void RegisterApiMiddlewares(this IApplicationBuilder app)
    {
        app.UseCors("AllowAll");
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
    #endregion

    #region Data Services
    public static void RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServerConnection");
        services.AddDbContext<TFDbContext>(opts =>
            opts.UseSqlServer(connectionString));

        // Register SeedData as a transient service
        services.AddTransient<SeedData>();

        // Add TondForoosh Repository to the DI
        services.AddScoped<ITondForooshRepository, EFTFRepository>();
    }

    public static void RegisterDataMiddlewares(this IApplicationBuilder app)
    {
        // Access IWebHostEnvironment using the ApplicationServices
        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

        if (env.IsDevelopment())
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var seedData = scope.ServiceProvider.GetRequiredService<SeedData>();
                seedData.Initialize();
            }
        }
    }
    #endregion

}
