using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Persistence;

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
        var profiles = assembly
            .GetTypes()
            .Where(t => !t.IsAbstract && !t.IsInterface &&
                t.IsAssignableTo(typeof(ErrorProfile)))
            .Select(t => ServiceDescriptor.Singleton(typeof(ErrorProfile), t));

        services.TryAddEnumerable(profiles);

        return services;
    }

    public static IServiceCollection AddErrorResponseGenerator<TErrorProfile>(this IServiceCollection services)
        where TErrorProfile : ErrorProfile
    {
        services.AddSingleton<TErrorProfile>();

        return services;
    }
}