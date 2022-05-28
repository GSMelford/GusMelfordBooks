using System.Net;
using GusMelfordBooks.CustomExceptions;
using Newtonsoft.Json;

namespace GusMelfordBooks.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        } catch (Exception ex) {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "Exception: {Message}", exception.Message);

        Error error = BuildError(exception);
        
        if (!context.Response.HasStarted) {
            context.Response.StatusCode = error.StatusCode;
        }

        return context.Response.WriteAsync(JsonConvert.SerializeObject(error));
    }

    private Error BuildError(Exception exception)
    {
        Error error = new Error();

        if (exception is UnauthorizedException unauthorizedException)
        {
            error.StatusCode = (int) HttpStatusCode.Unauthorized;
            error.Message = unauthorizedException.Message;
        }
        if (exception is ConflictException conflictException)
        {
            error.StatusCode = (int) HttpStatusCode.Conflict;
            error.Message = conflictException.Message;
        }
        else
        {
            error.StatusCode = (int) HttpStatusCode.BadRequest;
            error.Message = exception.Message;
        }

        return error;
    }
}