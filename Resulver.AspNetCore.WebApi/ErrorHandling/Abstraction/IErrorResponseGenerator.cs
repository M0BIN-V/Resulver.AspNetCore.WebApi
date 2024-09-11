namespace Resulver.AspNetCore.WebApi.ErrorHandling.Abstraction;

public interface IErrorResponseGenerator
{
    public IResult MakeResponse(ResultError error);
}