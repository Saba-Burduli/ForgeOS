using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace AiStartupOs.Api.Extensions;

public static class ObservabilityExtensions
{
    public static IServiceCollection AddObservability(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceName = configuration["OpenTelemetry:ServiceName"] ?? "ai-startup-os-api";
        var otlpEndpoint = configuration["OpenTelemetry:Otlp:Endpoint"];

        services
            .AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(serviceName))
            .WithTracing(tracerProviderBuilder =>
            {
                tracerProviderBuilder
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();

                if (!string.IsNullOrWhiteSpace(otlpEndpoint))
                {
                    tracerProviderBuilder.AddOtlpExporter(options => options.Endpoint = new Uri(otlpEndpoint));
                }
                else
                {
                    tracerProviderBuilder.AddOtlpExporter();
                }
            })
            .WithMetrics(meterProviderBuilder =>
            {
                meterProviderBuilder
                    .AddMeter("AiStartupOs")
                    .AddRuntimeInstrumentation()
                    .AddProcessInstrumentation();

                if (!string.IsNullOrWhiteSpace(otlpEndpoint))
                {
                    meterProviderBuilder.AddOtlpExporter(options => options.Endpoint = new Uri(otlpEndpoint));
                }
                else
                {
                    meterProviderBuilder.AddOtlpExporter();
                }
            });

        return services;
    }
}
