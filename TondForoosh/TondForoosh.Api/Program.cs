using Microsoft.AspNetCore.Authentication;
using TondForoosh.Api.Data;
using TondForoosh.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container using extension methods
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline using extension methods
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Automatically apply migrations
await app.MigrateDbAsync();

// Use application middlewares
app.UseApplicationMiddlewares();

// Map endpoints
app.MapApplicationEndpoints();

app.Run();
