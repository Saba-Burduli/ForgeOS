using AiStartupOs.BuildingBlocks.Persistence;
using AiStartupOs.Modules.FounderCopilot.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.FounderCopilot.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddFounderCopilotInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new InvalidOperationException("Database connection string is missing.");

        services.AddPostgresModuleDbContext<FounderCopilotDbContext>(connectionString, ModuleDefinition.Schema);

        return services;
    }
}
