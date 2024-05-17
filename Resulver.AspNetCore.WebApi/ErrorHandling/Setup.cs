using Microsoft.Extensions.DependencyInjection;

namespace Resulver.AspNetCore.WebApi.ErrorHandling;

public static class Setup
{
    public static IServiceCollection AddErrorHandler
        (this IServiceCollection services, params ErrorProfile[] errorProfiles)
    {
        var errors = new List<ErrorWithStatusCode>();

        foreach (var errorProfile in errorProfiles)
        {
            errors.AddRange(errorProfile.Errors);
        }

        services.AddSingleton<IErrorHandler>(new ErrorHandler(errors));

        return services;
    }
}
