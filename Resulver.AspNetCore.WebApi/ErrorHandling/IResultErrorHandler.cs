using Microsoft.AspNetCore.Mvc;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public interface IResultErrorHandler
{
    public int GetErrorStatusCode(IResultError error);
}