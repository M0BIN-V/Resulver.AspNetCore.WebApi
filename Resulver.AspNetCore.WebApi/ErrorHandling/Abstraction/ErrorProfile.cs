namespace Resulver.AspNetCore.WebApi.ErrorHandling.Abstraction;

public abstract class ErrorProfile
{
    protected static ErrorResponse AddError<TError>()
        where TError : ResultError
    {
        return new ErrorResponse(typeof(TError));
    }

    public abstract void ConfigureErrors();
}