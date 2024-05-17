using Microsoft.AspNetCore.Mvc;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public interface IErrorHandler
{
    public int GetErrorStatusCode(IResultError error);
}