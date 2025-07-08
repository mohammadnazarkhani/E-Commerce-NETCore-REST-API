using ECommerce.RestAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL DbContext
builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Migrate and update database at startup
app.MigrateAndSeedDatabase();

app.MapGet("/", () => "Hello World!");

app.Run();
