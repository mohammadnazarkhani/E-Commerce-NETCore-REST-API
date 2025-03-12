using TondForooshApi.Models;
using TondForooshApi.Services;
using Microsoft.OpenApi.Models;

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
