using AiStartupOs.BuildingBlocks.Persistence;
using AiStartupOs.Modules.StartupIdeas.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.StartupIdeas.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddStartupIdeasInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new InvalidOperationException("Database connection string is missing.");

        services.AddPostgresModuleDbContext<StartupIdeasDbContext>(connectionString, ModuleDefinition.Schema);

        return services;
    }
}
