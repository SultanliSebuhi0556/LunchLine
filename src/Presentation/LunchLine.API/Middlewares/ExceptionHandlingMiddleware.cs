using FluentValidation;

namespace LunchLine.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate _next)
{
    public async Task Invoke(HttpContext context)
    {
        try { await _next(context); }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new
            {
                Errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
            });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 400;
            if (ex.InnerException == null)
                await context.Response.WriteAsJsonAsync(new { Errors = ex.Message });
            else await context.Response.WriteAsJsonAsync(new { Errors = ex.InnerException.Message });
        }
    }
}