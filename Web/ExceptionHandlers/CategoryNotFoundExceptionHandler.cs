using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Web.ExceptionHandlers;

internal sealed class CategoryNotFoundExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not CategoryNotFoundException) return false;
        
        const string contentType = "application/problem+json";
        const int responseStatusCode = StatusCodes.Status404NotFound;
        
        httpContext.Response.ContentType = contentType;
        httpContext.Response.StatusCode = responseStatusCode;
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.5",
            Title = exception.Message,
            Status = responseStatusCode,
            Extensions =
            {
                ["traceId"] = httpContext.TraceIdentifier,
            }
        }, cancellationToken: cancellationToken);
            
        return true;
    }
}