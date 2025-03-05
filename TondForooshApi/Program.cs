using TondForooshApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterApiServices();
builder.Services.RegisterDataServices(builder.Configuration);

var app = builder.Build();

// Registering Api related middlewares
app.RegisterApiMiddlewares();

app.Run();
