namespace AiStartupOs.BuildingBlocks.Persistence;

public sealed class OutboxOptions
{
    public int PollIntervalSeconds { get; init; } = 5;

    public int BatchSize { get; init; } = 50;
}
