using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using AiStartupOs.BuildingBlocks.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AiStartupOs.Modules.ValidationEngine.Infrastructure;

public sealed class ValidationEngineDbContext : ModuleDbContext
{
    public ValidationEngineDbContext(DbContextOptions<ValidationEngineDbContext> options, IDomainEventDispatcher dispatcher)
        : base(options, dispatcher)
    {
    }
}
