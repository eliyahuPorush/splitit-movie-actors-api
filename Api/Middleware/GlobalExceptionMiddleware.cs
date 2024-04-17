using Domain.Exceptions;
using Newtonsoft.Json;

namespace Api.Middleware;

public class GlobalExceptionMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (DuplicateRankException e)
        {
            await Handle400ExceptionAsync(context, e);
        }
        catch (ActorNotExistException e)
        {
            await Handle400ExceptionAsync(context, e);
        }
        catch (Exception e)
        {
            await Handle500ExceptionAsync(context);
        }
    }
    
    private static Task Handle400ExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new { error = exception.Message };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
    
    private static Task Handle500ExceptionAsync(HttpContext context)
    {
        var response = new { error = "internal server error" };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}