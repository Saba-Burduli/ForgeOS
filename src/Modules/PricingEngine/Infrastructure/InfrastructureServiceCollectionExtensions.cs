using AiStartupOs.BuildingBlocks.Persistence;
using AiStartupOs.Modules.PricingEngine.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.PricingEngine.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddPricingEngineInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new InvalidOperationException("Database connection string is missing.");

        services.AddPostgresModuleDbContext<PricingEngineDbContext>(connectionString, ModuleDefinition.Schema);

        return services;
    }
}
