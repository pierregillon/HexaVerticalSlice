using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.AccountManagement.Contracts;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Register;

public class PublishIntegrationEvent(IIntegrationEventPublisher publisher) : IDomainEventListener<UserAccountRegistered>
{
    public Task On(UserAccountRegistered domainEvent) =>
        publisher.Publish(
            new UserAccountRegisteredIntegrationEvent(domainEvent.UserAccountId, domainEvent.EmailAddress)
        );
}