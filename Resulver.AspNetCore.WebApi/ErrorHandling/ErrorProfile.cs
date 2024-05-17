namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ErrorProfile
{
    public List<ErrorWithStatusCode> Errors { get; } = [];

    protected ErrorWithStatusCode AddError<TError>()
        where TError : IResultError
    {
        var errorWithStatus = new ErrorWithStatusCode
        {
            Error = typeof(TError)
        };

        Errors.Add(errorWithStatus);

        return errorWithStatus;
    }
}
