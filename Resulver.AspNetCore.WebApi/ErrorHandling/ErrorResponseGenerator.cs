using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ErrorResponseGenerator : IErrorResponseGenerator
{
    readonly Dictionary<Type, ErrorResponseHandler> _errorResponses = [];

    public ErrorResponseGenerator(IServiceProvider serviceProvider)
    {
        foreach (var errorProfile in serviceProvider.GetServices<ErrorProfile>())
        {
            foreach (var response in errorProfile.ErrorResponses)
            {
                _errorResponses.Add(response.ErrorType, response);
            }
        }
    }

    public IActionResult MakeResponse(ResultError error)
    {
        var errorResponse = _errorResponses.GetValueOrDefault(error.GetType())
            ?? throw new Exception($"Error profile for '{error.GetType().Name}' is not defined !");

        return errorResponse.Handler(error);
    }
}
