using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PatientMangementApi.PensionManagement.Application;
using PatientMangementApi.PensionManagement.Application.Implementation;
using PatientMangementApi.PensionManagement.Application.Interface;
using PatientMangementApi.PensionManagement.Domain;
using PatientMangementApi.PensionManagement.Infrastructure;
using PatientMangementApi.PensionManagement.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer(); // Required for minimal APIs to expose endpoints
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Patient Management API",
        Version = "v1",
        Description = "An API for managing patients",
    });
});

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase(databaseName: "PatientManagementDb"));

builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<Patient>, Repository<Patient>>();
builder.Services.AddScoped<IRepository<PatientRecord>, Repository<PatientRecord>>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientRecordService, PatientRecordService>();


var app = builder.Build();

await DataSeeder.Initialize(app.Services.CreateScope().ServiceProvider);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Patient Management API v1");
        options.RoutePrefix = string.Empty; // Swagger will be available at the root ("/")
    });
}

app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
