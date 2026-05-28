using System.Reflection;
using AiStartupOs.BuildingBlocks.Web;
using AiStartupOs.Modules.Billing.Presentation;
using AiStartupOs.Modules.FounderCopilot.Presentation;
using AiStartupOs.Modules.Identity.Presentation;
using AiStartupOs.Modules.LandingPageGenerator.Presentation;
using AiStartupOs.Modules.PersonaEngine.Presentation;
using AiStartupOs.Modules.PricingEngine.Presentation;
using AiStartupOs.Modules.ResearchEngine.Presentation;
using AiStartupOs.Modules.RoadmapEngine.Presentation;
using AiStartupOs.Modules.StartupIdeas.Presentation;
using AiStartupOs.Modules.ValidationEngine.Presentation;

namespace AiStartupOs.Api;

internal static class ModuleCatalog
{
    public static IReadOnlyCollection<IModule> Modules { get; } =
    [
        new IdentityModule(),
        new StartupIdeasModule(),
        new ValidationEngineModule(),
        new ResearchEngineModule(),
        new PersonaEngineModule(),
        new PricingEngineModule(),
        new RoadmapEngineModule(),
        new LandingPageGeneratorModule(),
        new FounderCopilotModule(),
        new BillingModule()
    ];

    public static IReadOnlyCollection<Assembly> ApplicationAssemblies { get; } =
    [
        typeof(AiStartupOs.Modules.Identity.Application.ApplicationAssemblyMarker).Assembly,
        typeof(AiStartupOs.Modules.StartupIdeas.Application.ApplicationAssemblyMarker).Assembly,
        typeof(AiStartupOs.Modules.ValidationEngine.Application.ApplicationAssemblyMarker).Assembly,
        typeof(AiStartupOs.Modules.ResearchEngine.Application.ApplicationAssemblyMarker).Assembly,
        typeof(AiStartupOs.Modules.PersonaEngine.Application.ApplicationAssemblyMarker).Assembly,
        typeof(AiStartupOs.Modules.PricingEngine.Application.ApplicationAssemblyMarker).Assembly,
        typeof(AiStartupOs.Modules.RoadmapEngine.Application.ApplicationAssemblyMarker).Assembly,
        typeof(AiStartupOs.Modules.LandingPageGenerator.Application.ApplicationAssemblyMarker).Assembly,
        typeof(AiStartupOs.Modules.FounderCopilot.Application.ApplicationAssemblyMarker).Assembly,
        typeof(AiStartupOs.Modules.Billing.Application.ApplicationAssemblyMarker).Assembly
    ];
}
