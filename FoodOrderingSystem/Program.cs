using FoodOrderingSystem.Repositories;
using FoodOrderingSystem.Services;
using FoodOrderingSystem.Profiles;
using FoodOrderingSystem.Middleware;
using FoodOrderingSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<RestaurantService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.Run();
