using AiStartupOs.BuildingBlocks.Messaging;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace AiStartupOs.Api.Extensions;

public static class HealthChecksExtensions
{
    public static IServiceCollection AddPlatformHealthChecks(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database")
            ?? throw new InvalidOperationException("Database connection string is missing.");
        var redisConnection = configuration.GetConnectionString("Redis")
            ?? throw new InvalidOperationException("Redis connection string is missing.");
        var rabbitMqOptions = configuration.GetSection("RabbitMq").Get<RabbitMqOptions>()
            ?? throw new InvalidOperationException("RabbitMq configuration is missing.");

        services
            .AddHealthChecks()
            .AddNpgSql(connectionString, name: "postgres", tags: ["ready"])
            .AddRedis(redisConnection, name: "redis", tags: ["ready"])
            .AddRabbitMQ(sp =>
            {
                var factory = sp.GetRequiredService<IConnectionFactory>();
                return factory.CreateConnectionAsync(CancellationToken.None).GetAwaiter().GetResult();
            }, name: "rabbitmq", tags: ["ready"]);

        return services;
    }
}
