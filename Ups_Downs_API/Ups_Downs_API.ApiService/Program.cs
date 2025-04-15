using Ups_Downs_API.ApiService.Services;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Hello from ups and downs api service");

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Register controllers
builder.Services.AddControllers();

// Sample service file below - registering for dependency injection
builder.Services.AddScoped<SkeletonService>();
builder.Services.AddScoped<ViewPostService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

// Enable API routes
app.MapControllers();

app.Run();
