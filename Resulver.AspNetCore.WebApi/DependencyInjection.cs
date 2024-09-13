using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Resulver.AspNetCore.WebApi.ErrorHandling;
using System.Reflection;

namespace Resulver.AspNetCore.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddErrorProfile<TErrorProfile>(this IServiceCollection services)
        where TErrorProfile : ErrorProfile
    {
        services.AddSingleton<TErrorProfile>();

        return services;
    }

    public static IServiceCollection AddErrorProfilesFromAssembly(
        this IServiceCollection services, Assembly assembly)
    {
        var errorProfiles = assembly
           .GetTypes()
           .Where(type => !type.IsAbstract && !type.IsInterface && type.IsAssignableTo(typeof(ErrorProfile)))
           .Select(profileType => (Activator.CreateInstance(profileType) as ErrorProfile)!);

        var serviceDescriptors = errorProfiles.Select(ServiceDescriptor.Singleton);

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IServiceCollection AddErrorResponseGenerator(this IServiceCollection services)
    {
        services.AddScoped<IErrorResponseGenerator, ErrorResponseGenerator>();

        return services;
    }
}