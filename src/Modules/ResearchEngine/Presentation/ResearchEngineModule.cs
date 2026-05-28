using AiStartupOs.BuildingBlocks.Web;
using AiStartupOs.Modules.ResearchEngine.Contracts;
using AiStartupOs.Modules.ResearchEngine.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.ResearchEngine.Presentation;

public sealed class ResearchEngineModule : IModule
{
    public string Name => ModuleDefinition.Name;

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddResearchEngineInfrastructure(configuration);
    }

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup($"/modules/{ModuleDefinition.Route}");
        group.MapGet("/status", () => Results.Ok(new { module = ModuleDefinition.Name, status = "ready" }));
    }
}
