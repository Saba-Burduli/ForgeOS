using MediatR;

namespace AiStartupOs.BuildingBlocks.Application.Abstractions;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest
{
}
