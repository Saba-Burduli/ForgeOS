using AiStartupOs.BuildingBlocks.Web;
using AiStartupOs.Modules.ValidationEngine.Contracts;
using AiStartupOs.Modules.ValidationEngine.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.ValidationEngine.Presentation;

public sealed class ValidationEngineModule : IModule
{
    public string Name => ModuleDefinition.Name;

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidationEngineInfrastructure(configuration);
    }

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup($"/modules/{ModuleDefinition.Route}");
        group.MapGet("/status", () => Results.Ok(new { module = ModuleDefinition.Name, status = "ready" }));
    }
}
