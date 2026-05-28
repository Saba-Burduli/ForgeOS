using AiStartupOs.Api;
using AiStartupOs.Api.Extensions;
using AiStartupOs.BuildingBlocks.Application.DependencyInjection;
using AiStartupOs.BuildingBlocks.Messaging;
using AiStartupOs.BuildingBlocks.Web;
using AiStartupOs.SharedKernel;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();

builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddApplicationCore(ModuleCatalog.ApplicationAssemblies);
builder.Services.AddRabbitMqEventBus(builder.Configuration);
builder.Services.AddPlatformHealthChecks(builder.Configuration);
builder.Services.AddObservability(builder.Configuration);
builder.Services.AddModules(ModuleCatalog.Modules, builder.Configuration);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.MapGet("/", () => Results.Ok(new
{
    service = "AI Startup OS",
    environment = app.Environment.EnvironmentName,
    version = typeof(Program).Assembly.GetName().Version?.ToString()
}));

app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready")
});

app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = _ => false
});

app.MapModuleEndpoints();

app.Run();
