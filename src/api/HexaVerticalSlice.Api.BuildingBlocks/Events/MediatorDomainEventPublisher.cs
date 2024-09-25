using MediatR;

namespace HexaVerticalSlice.Api.BuildingBlocks.Events;

internal class MediatorDomainEventPublisher(IPublisher publisher) : IDomainEventPublisher, IIntegrationEventPublisher
{
    public Task Publish(IDomainEvent domainEvent) => publisher.Publish(domainEvent);
    public Task Publish(IIntegrationEvent integrationEvent) => publisher.Publish(integrationEvent);
}