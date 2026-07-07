using FitTracker.Data;
using Microsoft.EntityFrameworkCore;
using FitTracker.Services.Interfaces;
using FitTracker.Services.Services;
using Scalar.AspNetCore;
using FitTracker.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<FitTrackerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDailyLogService, DailyLogService>();
builder.Services.AddScoped<IExerciseSessionService, ExerciseSessionService>();
builder.Services.AddScoped<IMealLogService, MealLogService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<FitTrackerMappingProfile>();
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
