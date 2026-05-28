namespace AiStartupOs.BuildingBlocks.Domain;

public abstract record DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; }

    public DateTimeOffset OccurredOn { get; }
}
