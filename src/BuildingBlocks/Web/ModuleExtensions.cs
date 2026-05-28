using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.BuildingBlocks.Web;

public static class ModuleExtensions
{
    public static IServiceCollection AddModules(
        this IServiceCollection services,
        IEnumerable<IModule> modules,
        IConfiguration configuration)
    {
        var moduleList = modules.ToArray();

        foreach (var module in moduleList)
        {
            module.Register(services, configuration);
        }

        services.AddSingleton<IEnumerable<IModule>>(moduleList);

        return services;
    }

    public static IEndpointRouteBuilder MapModuleEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var modules = endpoints.ServiceProvider.GetRequiredService<IEnumerable<IModule>>();

        foreach (var module in modules)
        {
            module.MapEndpoints(endpoints);
        }

        return endpoints;
    }
}
