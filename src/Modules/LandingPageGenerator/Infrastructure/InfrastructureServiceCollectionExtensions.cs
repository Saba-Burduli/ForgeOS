using AiStartupOs.BuildingBlocks.Persistence;
using AiStartupOs.Modules.LandingPageGenerator.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.LandingPageGenerator.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddLandingPageGeneratorInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new InvalidOperationException("Database connection string is missing.");

        services.AddPostgresModuleDbContext<LandingPageGeneratorDbContext>(
            connectionString,
            ModuleDefinition.Schema);

        return services;
    }
}
