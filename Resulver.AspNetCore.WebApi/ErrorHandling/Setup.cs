using Microsoft.Extensions.DependencyInjection;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public static class Setup
{
    public static IServiceCollection AddErrorHandler
        (this IServiceCollection services, params ResultErrorProfile[] errorProfiles)
    {
        var errors = new List<ResultErrorWithStatusCode>();

        foreach (var errorProfile in errorProfiles)
        {
            errors.AddRange(errorProfile.Errors);
        }

        services.AddSingleton<IResultErrorHandler>(new ResultErrorHandler(errors));

        return services;
    }
}
