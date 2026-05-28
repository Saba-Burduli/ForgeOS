namespace AiStartupOs.BuildingBlocks.Messaging;

public abstract record IntegrationEvent
{
    protected IntegrationEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; init; }

    public DateTimeOffset OccurredOn { get; init; }

    public string? CorrelationId { get; init; }
}
