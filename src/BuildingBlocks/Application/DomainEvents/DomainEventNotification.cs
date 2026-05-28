using AiStartupOs.BuildingBlocks.Domain;
using MediatR;

namespace AiStartupOs.BuildingBlocks.Application.DomainEvents;

public sealed record DomainEventNotification<TDomainEvent>(TDomainEvent DomainEvent) : INotification
    where TDomainEvent : IDomainEvent;
