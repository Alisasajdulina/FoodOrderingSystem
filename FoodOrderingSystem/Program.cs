using FoodOrderingSystem.Data;
using FoodOrderingSystem.Profiles;
using FoodOrderingSystem.Repositories;
using FoodOrderingSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "API работает");

app.MapControllers();
app.Run();
