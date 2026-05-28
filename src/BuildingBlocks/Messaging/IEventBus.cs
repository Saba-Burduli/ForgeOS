namespace AiStartupOs.BuildingBlocks.Messaging;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent integrationEvent, CancellationToken cancellationToken = default);
}
