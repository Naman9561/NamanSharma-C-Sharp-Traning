using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Add services for Swagger/OpenAPI documentation
builder.Services.AddEndpointsApiExplorer(); // Required for minimal APIs
builder.Services.AddSwaggerGen(); // Adds Swagger generation capabilities

// Correct connection string key here:
var connStr = builder.Configuration
    .GetConnectionString("NZWalksConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'NZWalksConnection' not found. Check appsettings.json"
    );

builder.Services.AddDbContext<NZWalksDbContext>(options =>
    options.UseSqlServer(connStr));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // serve JSON endpoint
    app.UseSwaggerUI();     // serve interactive UI
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
