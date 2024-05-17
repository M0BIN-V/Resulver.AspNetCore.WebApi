using Microsoft.AspNetCore.Mvc;
using Resulver.AspNetCore.WebApi.ErrorHandling;

namespace Resulver.AspNetCore.WebApi;

public class ResultBaseController : ControllerBase
{
    readonly IErrorHandler _errorHandler;

    public ResultBaseController(IErrorHandler errorHandler)
    {
        _errorHandler = errorHandler;
    }

    public IActionResult FromResult<TResultContent>(IResult<TResultContent> result, int SuccessStatusCode)
    {
        var response = ResponseBodyTemplateBuilder.Build(result);

        if (result.IsFailure)
        {
            SuccessStatusCode = _errorHandler.GetErrorStatusCode(result.Error!);
        }

        return new ObjectResult(response)
        {
            StatusCode = SuccessStatusCode,
        };
    }
}
