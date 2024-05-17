namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ResultErrorProfile
{
    public List<ResultErrorWithStatusCode> Errors { get; } = [];

    protected ResultErrorWithStatusCode AddError<TError>()
        where TError : IResultError
    {
        var errorWithStatus = new ResultErrorWithStatusCode
        {
            Error = typeof(TError)
        };

        Errors.Add(errorWithStatus);

        return errorWithStatus;
    }
}
