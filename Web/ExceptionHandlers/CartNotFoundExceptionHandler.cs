using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Web.ExceptionHandlers;

internal sealed class CartNotFoundExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not CartNotFoundException) return true;
        
        const string contentType = "application/problem+json";
        const int responseStatusCode = StatusCodes.Status404NotFound;
        
        httpContext.Response.ContentType = contentType;
        httpContext.Response.StatusCode = responseStatusCode;
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Title = exception.Message,
            Status = responseStatusCode,
        }, cancellationToken: cancellationToken);
            
        return false;
    }
}