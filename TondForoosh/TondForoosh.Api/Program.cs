using Microsoft.EntityFrameworkCore;
using TondForoosh.Api.Data;
using TondForoosh.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TondForooshContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TondForooshConnection"))
);

builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

// Register AuthService in Dependency Injection container
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
