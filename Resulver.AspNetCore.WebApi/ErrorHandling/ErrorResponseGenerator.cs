using Microsoft.Extensions.DependencyInjection;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public class ErrorResponseGenerator : IErrorResponseGenerator
{
    readonly Dictionary<Type, ErrorResponse> _errorResponses = [];

    public ErrorResponseGenerator(IServiceProvider serviceProvider)
    {
        foreach (var errorResponse in serviceProvider.GetServices<ErrorResponse>())
        {
            _errorResponses.Add(errorResponse.ErrorType, errorResponse);
        }
    }

    public IResult MakeResponse(ResultError error)
    {
        var errorResponse = _errorResponses.GetValueOrDefault(error.GetType())
            ?? throw new Exception($"Error profile for '{error.GetType().Name}' is not defined !");

        return errorResponse.Handler(error);
    }
}
