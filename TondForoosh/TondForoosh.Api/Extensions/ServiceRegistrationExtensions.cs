using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using TondForoosh.Api.Services;
using TondForoosh.Api.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Entities;
using TondForoosh.Api.Mapping;
using TondForoosh.Api.Endpoints.Handlers;

namespace TondForoosh.Api.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        // Register services required for the application
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Add DbContext
            services.AddDbContext<TondForooshContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TondForooshConnection"))
            );

            // Add AutoMapper
            services.AddAutoMapper(typeof(TondForooshMappingProfile));

            // Register UnitOfWork as Scoped
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register authentication services
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var secretKey = configuration["JwtSettings:SecretKey"];
                    var key = Encoding.UTF8.GetBytes(secretKey);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            // Register authorization policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(UserRole.Admin.ToString()));
                options.AddPolicy("SellerOnly", policy => policy.RequireRole(UserRole.Seller.ToString()));
                options.AddPolicy("UserOnly", policy => policy.RequireRole(UserRole.User.ToString()));
                options.AddPolicy("AdminOrSeller", policy => policy.RequireRole(UserRole.Admin.ToString(), UserRole.Seller.ToString()));
            });

            // Register IHttpContextAccessor
            services.AddHttpContextAccessor();

            // Register password hashing and authentication services
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<TokenGenerator>();  // Add TokenGenerator to DI container

            // Register AuthenticationHandler to the DI container
            // This allows AuthenticationHandler to be injected wherever it is needed in the application
            services.AddScoped<AuthenticationHandler>();
        }
    }
}
