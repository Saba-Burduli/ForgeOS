using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using AiStartupOs.BuildingBlocks.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AiStartupOs.Modules.PersonaEngine.Infrastructure;

public sealed class PersonaEngineDbContext : ModuleDbContext
{
    public PersonaEngineDbContext(DbContextOptions<PersonaEngineDbContext> options, IDomainEventDispatcher dispatcher)
        : base(options, dispatcher)
    {
    }
}
