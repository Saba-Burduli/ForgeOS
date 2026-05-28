using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using AiStartupOs.BuildingBlocks.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AiStartupOs.Modules.LandingPageGenerator.Infrastructure;

public sealed class LandingPageGeneratorDbContext : ModuleDbContext
{
    public LandingPageGeneratorDbContext(
        DbContextOptions<LandingPageGeneratorDbContext> options,
        IDomainEventDispatcher dispatcher)
        : base(options, dispatcher)
    {
    }
}
