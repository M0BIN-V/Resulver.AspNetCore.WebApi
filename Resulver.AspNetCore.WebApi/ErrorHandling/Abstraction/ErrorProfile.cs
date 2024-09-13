namespace Resulver.AspNetCore.WebApi.ErrorHandling.Abstraction;

public abstract class ErrorProfile
{
    public List<ErrorResponse> ErrorResponses { get; private set; } = [];

    protected ErrorResponse AddError<TError>()
        where TError : ResultError
    {
        var errorResponse = new ErrorResponse(typeof(TError));

        ErrorResponses.Add(errorResponse);

        return errorResponse;
    }
}