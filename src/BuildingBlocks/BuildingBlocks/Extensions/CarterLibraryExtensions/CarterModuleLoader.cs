using System.Reflection;
using Carter;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Extensions.CarterLibraryExtensions;

public static class CarterModuleLoader
{
    public static IServiceCollection AddCarterFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        services.AddCarter();
        var moduleTypes = assembly
            .GetTypes()
            .Where(t => typeof(ICarterModule).IsAssignableFrom(t) && t is { IsAbstract: false, IsClass: true });

        foreach (var type in moduleTypes)
        {
            services.AddTransient(typeof(ICarterModule), type);
        }

        return services;
    }
}

