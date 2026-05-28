using System.Text.Json;
using AiStartupOs.BuildingBlocks.Messaging;

namespace AiStartupOs.BuildingBlocks.Persistence;

public sealed class OutboxMessage
{
    public Guid Id { get; init; }

    public DateTimeOffset OccurredOn { get; init; }

    public string Type { get; init; } = string.Empty;

    public string Content { get; init; } = string.Empty;

    public string? CorrelationId { get; init; }

    public int Attempts { get; set; }

    public DateTimeOffset? LastAttemptOn { get; set; }

    public DateTimeOffset? ProcessedOn { get; set; }

    public string? Error { get; set; }

    public static OutboxMessage FromIntegrationEvent(
        IntegrationEvent integrationEvent,
        JsonSerializerOptions? options = null)
    {
        var serializerOptions = options ?? new JsonSerializerOptions(JsonSerializerDefaults.Web);

        return new OutboxMessage
        {
            Id = integrationEvent.Id,
            OccurredOn = integrationEvent.OccurredOn,
            Type = integrationEvent.GetType().AssemblyQualifiedName
                ?? integrationEvent.GetType().FullName
                ?? integrationEvent.GetType().Name,
            Content = JsonSerializer.Serialize(integrationEvent, integrationEvent.GetType(), serializerOptions),
            CorrelationId = integrationEvent.CorrelationId
        };
    }
}
