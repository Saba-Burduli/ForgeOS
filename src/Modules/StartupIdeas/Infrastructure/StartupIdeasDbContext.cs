using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using AiStartupOs.BuildingBlocks.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AiStartupOs.Modules.StartupIdeas.Infrastructure;

public sealed class StartupIdeasDbContext : ModuleDbContext
{
    public StartupIdeasDbContext(DbContextOptions<StartupIdeasDbContext> options, IDomainEventDispatcher dispatcher)
        : base(options, dispatcher)
    {
    }
}
