using ECommerce.RestAPI.Data;
using ECommerce.RestAPI.Data.Extensions;
using ECommerce.RestAPI.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL DbContext
builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Migrate and update database at startup
app.MigrateAndSeedDatabase();

app.MapGet("/", () => "Hello World!");

app.Run();
