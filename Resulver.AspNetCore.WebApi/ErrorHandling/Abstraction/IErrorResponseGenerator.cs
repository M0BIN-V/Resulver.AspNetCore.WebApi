using Microsoft.AspNetCore.Mvc;

namespace Resulver.AspNetCore.WebApi.ErrorHandling.Abstraction;

public interface IErrorResponseGenerator
{
    public IActionResult MakeResponse(ResultError error);
}