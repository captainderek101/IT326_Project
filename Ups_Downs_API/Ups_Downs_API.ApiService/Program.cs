using Microsoft.EntityFrameworkCore;
using Ups_Downs_API.ApiService.Services;
using Library;
using Microsoft.AspNetCore.Identity;
using Ups_Downs_API.ApiService.Database;

var builder = WebApplication.CreateBuilder(args);


// This is a singleton class that will be used to store the user information in memory. It is not recommended to use this in production, but it is useful for testing purposes.
builder.Services.AddSingleton<TempGlobalSingleton>(); 

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
builder.Services.AddScoped<CreatingPostService>();
builder.Services.AddScoped<LoginService>();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

// Enable API routes
app.MapControllers();

app.Run();
