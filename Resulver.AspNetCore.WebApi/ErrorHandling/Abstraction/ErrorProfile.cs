namespace Resulver.AspNetCore.WebApi.ErrorHandling.Abstraction;

public abstract class ErrorProfile
{
    public List<ErrorResponseHandler> ErrorResponses { get; } = [];

    protected ErrorResponseHandler AddError<TError>()
        where TError : ResultError
    {
        var errorResponse = new ErrorResponseHandler(typeof(TError));

        ErrorResponses.Add(errorResponse);

        return errorResponse;
    }
}