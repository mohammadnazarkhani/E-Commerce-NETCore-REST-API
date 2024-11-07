using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Data;
using TondForoosh.Api.Endpoints;
using TondForoosh.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TondForooshContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TondForooshConnection"))
);

builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<TokenGenerator>();  // Add TokenGenerator to DI container

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map Endpoints
app.MapAuthenticationEndpoints();

app.Run();
