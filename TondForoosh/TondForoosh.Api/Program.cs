using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Data;
using TondForoosh.Api.Endpoints;
using TondForoosh.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext and Connection String
builder.Services.AddDbContext<TondForooshContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TondForooshConnection"))
);

// Add required services for Password Hashing, Auth, Token Generator, etc.
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<TokenGenerator>();  // Add TokenGenerator to DI container

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var secretKey = builder.Configuration["JwtSettings:SecretKey"];
        var key = Encoding.UTF8.GetBytes(secretKey);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Automatically apply migrations
await app.MigrateDbAsync();

app.UseHttpsRedirection();

// Use Authentication middleware
app.UseAuthentication();  

// Use Authorization middleware 
app.UseAuthorization();

// Map Endpoints (Register, Login, etc.)
app.MapAuthenticationEndpoints();

app.Run();
