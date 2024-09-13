using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Resulver.AspNetCore.WebApi;

public class ResultBaseController : ControllerBase
{
    IErrorResponseGenerator ErrorResponseGenerator
    {
        get => ControllerContext.HttpContext.RequestServices.GetRequiredService<IErrorResponseGenerator>();
    }

    protected IActionResult FromResult(Result result, Func<IActionResult> successAction)
    {
        if (result.IsSuccess)
        {
            return successAction();
        }
        else
        {
            return ErrorResponseGenerator.MakeResponse(result.Errors[0]);
        }
    }
}
