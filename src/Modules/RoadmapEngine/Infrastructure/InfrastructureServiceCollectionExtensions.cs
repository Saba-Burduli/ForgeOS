using AiStartupOs.BuildingBlocks.Persistence;
using AiStartupOs.Modules.RoadmapEngine.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.RoadmapEngine.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddRoadmapEngineInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new InvalidOperationException("Database connection string is missing.");

        services.AddPostgresModuleDbContext<RoadmapEngineDbContext>(connectionString, ModuleDefinition.Schema);

        return services;
    }
}
