using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace AiStartupOs.BuildingBlocks.Messaging;

public sealed class RabbitMqEventBus : IEventBus
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    private readonly RabbitMqConnection _connection;
    private readonly RabbitMqOptions _options;
    private readonly ILogger<RabbitMqEventBus> _logger;

    public RabbitMqEventBus(
        RabbitMqConnection connection,
        IOptions<RabbitMqOptions> options,
        ILogger<RabbitMqEventBus> logger)
    {
        _connection = connection;
        _options = options.Value;
        _logger = logger;
    }

    public async Task PublishAsync(IntegrationEvent integrationEvent, CancellationToken cancellationToken = default)
    {
        var connection = await _connection.GetConnectionAsync(cancellationToken).ConfigureAwait(false);
        await using var channel = await connection
            .CreateChannelAsync(new CreateChannelOptions(true, true, null, null), cancellationToken)
            .ConfigureAwait(false);

        await channel.ExchangeDeclareAsync(
                exchange: _options.ExchangeName,
                type: ExchangeType.Topic,
                durable: true,
                autoDelete: false,
                arguments: null,
                passive: false,
                noWait: false,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var payload = JsonSerializer.SerializeToUtf8Bytes(integrationEvent, integrationEvent.GetType(), SerializerOptions);
        var properties = new BasicProperties
        {
            MessageId = integrationEvent.Id.ToString(),
            Timestamp = new AmqpTimestamp(integrationEvent.OccurredOn.ToUnixTimeSeconds()),
            Type = integrationEvent.GetType().FullName,
            CorrelationId = integrationEvent.CorrelationId,
            DeliveryMode = DeliveryModes.Persistent
        };

        await channel.BasicPublishAsync(
                exchange: _options.ExchangeName,
                routingKey: integrationEvent.GetType().Name,
                mandatory: true,
                basicProperties: properties,
                body: payload,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        _logger.LogInformation(
            "Published integration event {EventType} with id {EventId}",
            integrationEvent.GetType().Name,
            integrationEvent.Id);

    }
}
