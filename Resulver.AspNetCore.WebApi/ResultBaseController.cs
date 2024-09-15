using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Resulver.AspNetCore.WebApi.Response;

namespace Resulver.AspNetCore.WebApi;

public class ResultBaseController : ControllerBase
{
    IErrorResponseGenerator ErrorResponseGenerator
    {
        get => ControllerContext.HttpContext.RequestServices.GetRequiredService<IErrorResponseGenerator>();
    }

    protected IActionResult FromResult(Result result, Func<IActionResult> successAction)
    {
        if (result.IsFailure)
        {
            return ErrorResponseGenerator.MakeResponse(result.Errors[0]);
        }

        return successAction();
    }
    protected IActionResult FromResult(Result result, int successStatusCode = 200)
    {
        if (result.IsFailure)
        {
            return ErrorResponseGenerator.MakeResponse(result.Errors[0]);
        }

        return new ObjectResult(result.ToResponseTemplate())
        {
            StatusCode = successStatusCode
        };
    }
    protected IActionResult FromResult<TContent>(Result<TContent> result, int successStatusCode = 200)
    {
        if (result.IsFailure)
        {
            return ErrorResponseGenerator.MakeResponse(result.Errors[0]);
        }

        return new ObjectResult(result.ToResponseTemplate())
        {
            StatusCode = successStatusCode
        };
    }
}