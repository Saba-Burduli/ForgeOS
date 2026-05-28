using AiStartupOs.BuildingBlocks.Persistence;
using AiStartupOs.Modules.ValidationEngine.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.Modules.ValidationEngine.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddValidationEngineInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new InvalidOperationException("Database connection string is missing.");

        services.AddPostgresModuleDbContext<ValidationEngineDbContext>(connectionString, ModuleDefinition.Schema);

        return services;
    }
}
