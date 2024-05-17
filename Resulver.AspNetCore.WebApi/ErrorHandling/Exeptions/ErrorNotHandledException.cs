namespace Resulver.AspNetCore.WebApi.ErrorHandling.Exeptions;

public class ErrorNotHandledException : Exception
{
    public ErrorNotHandledException()
    {
    }

    public ErrorNotHandledException(string? message) : base(message)
    {
    }

    public ErrorNotHandledException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
