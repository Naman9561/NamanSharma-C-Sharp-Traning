using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Enable support for Swagger/OpenAPI (used for API documentation and testing)
builder.Services.AddEndpointsApiExplorer();  // Enables discovery of endpoints
builder.Services.AddSwaggerGen();            // Adds Swagger document generation

// Read and validate the connection string from appsettings.json
var connStr = builder.Configuration
    .GetConnectionString("NZWalksConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'NZWalksConnection' not found. Check appsettings.json"
    );

// Register and configure Entity Framework with SQL Server using the connection string
builder.Services.AddDbContext<NZWalksDbContext>(options =>
    options.UseSqlServer(connStr));

// Register the repository for dependency injection
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

// Register AutoMapper and load mapping profiles from the specified class
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();    // Serve Swagger JSON documentation
    app.UseSwaggerUI();  // Serve the interactive Swagger UI
}

app.UseHttpsRedirection(); // Enforce HTTPS

app.UseAuthorization();    // Enable Authorization middleware (authentication can be added later)

// Map controller endpoints (attribute routing)
app.MapControllers();

// Run the application
app.Run();
