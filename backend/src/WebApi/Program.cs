using WebApi.Services;
using Microsoft.OpenApi.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterApiServices();
builder.Services.RegisterDataServices(builder.Configuration);

// Add Swagger service
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TondForoosh", Version = "v1" });
});

var app = builder.Build();

// Apply migrations and update the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TFDbContext>();
        context.Database.Migrate(); // Apply pending migrations
    }
    catch (Exception ex)
    {
        // Log the exception (optional)
        Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
    }
}

// Use Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "TondForoosh");
});

// Registering Api related middlewares
app.RegisterApiMiddlewares();

// Registering Data related middlewares
app.RegisterDataMiddlewares();

app.Run();
