using System.Reflection;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs;
using Microsoft.Extensions.DependencyInjection;

namespace HexaVerticalSlice.Api.BuildingBlocks.Events;

public static class DependencyInjection
{
    private static readonly InterfaceTypeCollection DomainEventTypesToRegister = new(
    [
        typeof(IDomainEvent),
        typeof(IDomainEventListener<>),
        typeof(IIntegrationEvent),
        typeof(IIntegrationEventListener<>)
    ]);

    public static IServiceCollection AddDomainEventPublishing(
        this IServiceCollection services,
        params Assembly[] domainEventHandlerAssemblies
    )
    {
        if (domainEventHandlerAssemblies.Length == 0)
        {
            // auto register nothing, but initialize Mediator
            services.AddMediatR(x =>
            {
                x.TypeEvaluator = _ => false;
                x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
        }
        else
        {
            services.AddMediatR(x =>
            {
                x.TypeEvaluator = DomainEventTypesToRegister.IsValid;
                x.RegisterServicesFromAssemblies(domainEventHandlerAssemblies);
            });
        }

        services.AddTransient<IDomainEventPublisher, MediatorDomainEventPublisher>();
        services.AddTransient<IIntegrationEventPublisher, MediatorDomainEventPublisher>();

        return services;
    }
}