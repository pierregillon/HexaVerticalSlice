using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.AccountManagement.Contracts;
using HexaVerticalSlice.BC.AccountManagement.Domain;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Register.Infra;

public class PublishIntegrationEvent(IIntegrationEventPublisher publisher) : IDomainEventListener<UserAccountRegistered>
{
    public Task On(UserAccountRegistered domainEvent) =>
        publisher.Publish(
            new UserAccountRegisteredIntegrationEvent(domainEvent.UserAccountId, domainEvent.EmailAddress)
        );
}