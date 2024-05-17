namespace Resulver.AspNetCore.WebApi.ErrorHandling.Exeptions;

public class StatusCodeNotDefinedException : Exception
{
    public StatusCodeNotDefinedException()
    {
    }

    public StatusCodeNotDefinedException(string? message) : base(message)
    {
    }

    public StatusCodeNotDefinedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
