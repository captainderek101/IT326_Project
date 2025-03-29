var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Hello from ups and downs api service");

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Register controllers
builder.Services.AddControllers(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapDefaultEndpoints();

// Enable API routes
app.MapControllers();

app.Run();
