namespace AiStartupOs.BuildingBlocks.Domain;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTimeOffset OccurredOn { get; }
}
