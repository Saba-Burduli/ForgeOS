using System.Reflection;
using AiStartupOs.BuildingBlocks.Application.Behaviors;
using AiStartupOs.BuildingBlocks.Application.DomainEvents;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AiStartupOs.BuildingBlocks.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationCore(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        var assemblyList = assemblies as Assembly[] ?? assemblies.ToArray();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblyList));
        services.AddValidatorsFromAssemblies(assemblyList, includeInternalTypes: true);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        return services;
    }
}
