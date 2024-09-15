using Microsoft.AspNetCore.Mvc;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ErrorResponseHandler
{
    public int StatusCode { get; private set; } = StatusCodes.Status400BadRequest;
    public Func<ResultError, IActionResult> Handler { get; private set; }
    public Type ErrorType { get; }

    public ErrorResponseHandler(Type errorType)
    {
        Handler = error => new ObjectResult(error)
        {
            StatusCode = StatusCode
        };
        ErrorType = errorType;
    }

    public void WithStatusCode(int statusCode)
    {
        StatusCode = statusCode;
    }

    public ErrorResponseHandler HandleWith(Func<ResultError, IActionResult> handler)
    {
        Handler = handler;

        return this;
    }
}
