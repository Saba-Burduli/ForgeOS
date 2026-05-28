using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using AiStartupOs.BuildingBlocks.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AiStartupOs.Modules.FounderCopilot.Infrastructure;

public sealed class FounderCopilotDbContext : ModuleDbContext
{
    public FounderCopilotDbContext(DbContextOptions<FounderCopilotDbContext> options, IDomainEventDispatcher dispatcher)
        : base(options, dispatcher)
    {
    }
}
