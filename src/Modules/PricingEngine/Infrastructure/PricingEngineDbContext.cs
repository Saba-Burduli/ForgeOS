using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using AiStartupOs.BuildingBlocks.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AiStartupOs.Modules.PricingEngine.Infrastructure;

public sealed class PricingEngineDbContext : ModuleDbContext
{
    public PricingEngineDbContext(DbContextOptions<PricingEngineDbContext> options, IDomainEventDispatcher dispatcher)
        : base(options, dispatcher)
    {
    }
}
