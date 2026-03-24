using FluentValidation;

namespace LunchLine.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate _next)
{
    public async Task Invoke(HttpContext context)
    {
        try { await _next(context); }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new { Errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }) });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            string message = ex.InnerException?.Message ?? ex.Message;
            var cleanMessage = message.Replace("\r", "").Replace("\n", " ").Trim();
            await context.Response.WriteAsJsonAsync(new { Errors = cleanMessage });
        }
    }
}