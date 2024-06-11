using Microsoft.AspNetCore.Mvc;
using Resulver.AspNetCore.WebApi.ErrorHandling;

namespace Resulver.AspNetCore.WebApi;

public class ResultBaseController : ControllerBase
{
    readonly IResultErrorHandler _errorHandler;

    public ResultBaseController(IResultErrorHandler errorHandler)
    {
        _errorHandler = errorHandler;
    }

    public IActionResult FromResult<TResultContent>(Result<TResultContent> result, int successStatusCode)
    {
        var response = result.ToResponseBody();

        return new ObjectResult(response)
        {
            StatusCode = GetResultStatusCode(result.Errors, successStatusCode)
        };
    }

    public IActionResult FromResult(IResult result, int successStatusCode)
    {
        var response = result.ToResponseBody();

        return new ObjectResult(response)
        {
            StatusCode = GetResultStatusCode(result.Errors, successStatusCode)
        };
    }

    int GetResultStatusCode(List<IResultError> errors, int successStatusCode)
    {
        return errors.Count > 0 ? _errorHandler.GetErrorStatusCode(errors[0]) : successStatusCode;
    }
}
