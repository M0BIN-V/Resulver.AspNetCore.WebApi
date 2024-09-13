using Microsoft.AspNetCore.Mvc;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ErrorResponse
{
    public int StatusCode { get; private set; }
    public Func<ResultError, IActionResult> Handler { get; private set; }
    public Type ErrorType { get; }

    public ErrorResponse(Type errorType)
    {
        Handler = error => new ObjectResult(error)
        {
            StatusCode = StatusCodes.Status400BadRequest
        };
        ErrorType = errorType;
    }

    public void WithStatusCode(int statusCode)
    {
        StatusCode = statusCode;
    }

    public ErrorResponse HandleWith(Func<ResultError, IActionResult> handler)
    {
        Handler = handler;

        return this;
    }
}
