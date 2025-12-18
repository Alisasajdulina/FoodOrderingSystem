using System.Net;
using System.Text.Json;

namespace FoodOrderingSystem.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new
            {
                status = 500,
                message = "Внутренняя ошибка сервера"
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
