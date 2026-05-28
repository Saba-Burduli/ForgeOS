using AiStartupOs.BuildingBlocks.Domain;
using MediatR;

namespace AiStartupOs.BuildingBlocks.Application.DomainEvents;

public sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
    {
        foreach (var domainEvent in domainEvents)
        {
            var notification = CreateNotification(domainEvent);
            await _mediator.Publish(notification, cancellationToken).ConfigureAwait(false);
        }
    }

    private static INotification CreateNotification(IDomainEvent domainEvent)
    {
        var notificationType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
        var notification = Activator.CreateInstance(notificationType, domainEvent);

        return notification as INotification
            ?? throw new InvalidOperationException($"Unable to create notification for {domainEvent.GetType().Name}.");
    }
}
