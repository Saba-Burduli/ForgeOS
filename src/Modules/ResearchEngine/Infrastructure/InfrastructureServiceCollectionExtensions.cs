using AiStartupOs.BuildingBlocks.Persistence;
using AiStartupOs.Modules.ResearchEngine.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.ResearchEngine.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddResearchEngineInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new InvalidOperationException("Database connection string is missing.");

        services.AddPostgresModuleDbContext<ResearchEngineDbContext>(connectionString, ModuleDefinition.Schema);

        return services;
    }
}
