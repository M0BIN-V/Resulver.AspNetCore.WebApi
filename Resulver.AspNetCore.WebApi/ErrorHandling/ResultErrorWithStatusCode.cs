namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ResultErrorWithStatusCode
{
    public required Type Error { get; set; }
    public int StatusCode { get; set; }

    public void WithStatusCode(int statusCode)
    {
        StatusCode = statusCode;
    }
}
