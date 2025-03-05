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
        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
    }

    public static void RegisterApiMiddlewares(this IApplicationBuilder app)
    {
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
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
    }
    #endregion

}
