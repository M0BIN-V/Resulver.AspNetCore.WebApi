namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ErrorWithStatusCode
{
    public required Type Error { get; set; }
    public int StatusCode { get; set; }

    public void WithStatusCode(int statusCode)
    {
        StatusCode = statusCode;
    }
}
