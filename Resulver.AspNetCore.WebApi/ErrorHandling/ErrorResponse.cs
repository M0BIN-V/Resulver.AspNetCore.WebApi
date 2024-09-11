namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ErrorResponse
{
    public int StatusCode { get; private set; }
    public Func<ResultError, IResult> Handler { get; private set; }
    public Type ErrorType { get; }

    public ErrorResponse(Type errorType)
    {
        Handler = error => Results.BadRequest(error);
        ErrorType = errorType;
    }

    public void WithStatusCode(int statusCode)
    {
        StatusCode = statusCode;
    }

    public ErrorResponse HandleWith(Func<ResultError, IResult> handler)
    {
        Handler = handler;

        return this;
    }
}
