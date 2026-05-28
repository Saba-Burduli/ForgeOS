using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using AiStartupOs.BuildingBlocks.Domain;
using Microsoft.EntityFrameworkCore;

namespace AiStartupOs.BuildingBlocks.Persistence;

public abstract class ModuleDbContext : DbContext
{
    private readonly IDomainEventDispatcher _dispatcher;

    protected ModuleDbContext(DbContextOptions options, IDomainEventDispatcher dispatcher)
        : base(options)
    {
        _dispatcher = dispatcher;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker
            .Entries<IHasDomainEvents>()
            .SelectMany(entry => entry.Entity.DomainEvents)
            .ToList();

        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (domainEvents.Count == 0)
        {
            return result;
        }

        await _dispatcher.DispatchAsync(domainEvents, cancellationToken).ConfigureAwait(false);

        foreach (var entity in ChangeTracker.Entries<IHasDomainEvents>())
        {
            entity.Entity.ClearDomainEvents();
        }

        return result;
    }
}
