using Microsoft.EntityFrameworkCore;
using spotify.Data;
using spotify.Repositories;
using spotify.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi(); // existing helper in the project

// Configure EF Core DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    // Fallback to a local SQLite DB when no connection string is provided
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data Source=spotify.db"));
}
else
{
    // Use SQL Server when a connection string is present
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}

// Register repositories and services
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<ISongService, SongService>();
builder.Services.AddScoped<IArtistService, ArtistService>();

// OpenAPI / Swagger helpers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
