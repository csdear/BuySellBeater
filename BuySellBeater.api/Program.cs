using BuySellBeater.Api.Persistence;
using BuySellBeater.api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 1. Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddControllers();

// 2. Register EF Core DbContext
builder.Services.AddDbContext<BuySellBeaterDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BuySellBeaterDatabase")));

var app = builder.Build();

// Create database and seed default data on first run.
// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<BuySellBeaterDBContext>();
//     context.Database.EnsureCreated();

//     if (!context.Makes.Any())
//     {
//         var ford = new Make
//         {
//             Name = "Ford",
//             Models = new List<Model>
//             {
//                 new Model { Name = "Mustang" }
//             }
//         };

//         var chevy = new Make
//         {
//             Name = "Chevy",
//             Models = new List<Model>
//             {
//                 new Model { Name = "Camaro" }
//             }
//         };

//         var dodge = new Make
//         {
//             Name = "Dodge",
//             Models = new List<Model>
//             {
//                 new Model { Name = "Challenger" }
//             }
//         };

//         context.Makes.AddRange(ford, chevy, dodge);
//         context.SaveChanges();
//     }
// }

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BuySellBeaterDBContext>();
    context.Database.Migrate();
}

// 2. Enable CORS middleware (placed BEFORE UseAuthorization / MapControllers)
app.UseCors("AllowAngularClient");

app.UseAuthorization();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Coool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/", () => "BuySellBeater API is running.");

// Random
app.MapGet("/api/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
