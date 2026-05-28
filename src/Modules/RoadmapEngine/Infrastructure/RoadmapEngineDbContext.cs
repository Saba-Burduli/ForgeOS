using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using AiStartupOs.BuildingBlocks.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AiStartupOs.Modules.RoadmapEngine.Infrastructure;

public sealed class RoadmapEngineDbContext : ModuleDbContext
{
    public RoadmapEngineDbContext(DbContextOptions<RoadmapEngineDbContext> options, IDomainEventDispatcher dispatcher)
        : base(options, dispatcher)
    {
    }
}
