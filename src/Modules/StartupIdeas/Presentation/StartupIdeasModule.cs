using AiStartupOs.BuildingBlocks.Web;
using AiStartupOs.Modules.StartupIdeas.Contracts;
using AiStartupOs.Modules.StartupIdeas.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.StartupIdeas.Presentation;

public sealed class StartupIdeasModule : IModule
{
    public string Name => ModuleDefinition.Name;

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddStartupIdeasInfrastructure(configuration);
    }

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup($"/modules/{ModuleDefinition.Route}");
        group.MapGet("/status", () => Results.Ok(new { module = ModuleDefinition.Name, status = "ready" }));
    }
}
