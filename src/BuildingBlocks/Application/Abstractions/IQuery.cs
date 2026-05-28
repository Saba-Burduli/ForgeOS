using MediatR;

namespace AiStartupOs.BuildingBlocks.Application.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
