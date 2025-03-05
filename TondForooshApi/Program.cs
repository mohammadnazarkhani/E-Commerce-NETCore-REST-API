using TondForooshApi.Models;
using TondForooshApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterApiServices();
builder.Services.RegisterDataServices(builder.Configuration);

var app = builder.Build();

// Registering Api related middlewares
app.RegisterApiMiddlewares();

// Registering Data related middlewares
app.RegisterDataMiddlewares();

app.Run();
