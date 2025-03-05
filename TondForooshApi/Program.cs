using TondForooshApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterApiServices();

var app = builder.Build();

// Registering Api related middlewares
app.RegisterApiMiddlewares();

app.Run();
