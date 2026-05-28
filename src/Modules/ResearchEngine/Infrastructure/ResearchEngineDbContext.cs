using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using AiStartupOs.BuildingBlocks.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AiStartupOs.Modules.ResearchEngine.Infrastructure;

public sealed class ResearchEngineDbContext : ModuleDbContext
{
    public ResearchEngineDbContext(DbContextOptions<ResearchEngineDbContext> options, IDomainEventDispatcher dispatcher)
        : base(options, dispatcher)
    {
    }
}
