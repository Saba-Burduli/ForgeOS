using System.Threading;
using RabbitMQ.Client;

namespace AiStartupOs.BuildingBlocks.Messaging;

public sealed class RabbitMqConnection : IDisposable
{
    private readonly IConnectionFactory _factory;
    private readonly SemaphoreSlim _sync = new(1, 1);
    private IConnection? _connection;

    public RabbitMqConnection(IConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IConnection> GetConnectionAsync(CancellationToken cancellationToken = default)
    {
        if (_connection is { IsOpen: true })
        {
            return _connection;
        }

        await _sync.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_connection is { IsOpen: true })
            {
                return _connection;
            }

            _connection?.Dispose();
            _connection = await _factory.CreateConnectionAsync(cancellationToken).ConfigureAwait(false);

            return _connection;
        }
        finally
        {
            _sync.Release();
        }
    }

    public void Dispose()
    {
        _connection?.Dispose();
        _sync.Dispose();
    }
}
