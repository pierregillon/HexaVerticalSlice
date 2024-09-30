using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.Networking.Contracts;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;
using HexaVerticalSlice.BC.Networking.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.Networking.SideEffects.ConnectProfilesOnInvitationAccepted;

public class PublishIntegrationEvent(IIntegrationEventPublisher publisher, NetworkingDbContext dbContext)
    : IDomainEventListener<ProfileConnected>
{
    public async Task On(ProfileConnected domainEvent)
    {
        var profilesToAccountId = await dbContext.Profiles
            .Where(x => x.Id == domainEvent.Id.Value || x.Id == domainEvent.ProfileId.Value)
            .ToDictionaryAsync(x => x.Id, x => x.UserAccountId);

        await publisher.Publish(
            new ProfileConnectedIntegrationEvent(
                domainEvent.Id.Value,
                profilesToAccountId[domainEvent.Id.Value],
                domainEvent.ProfileId.Value,
                profilesToAccountId[domainEvent.ProfileId.Value]
            )
        );
    }
}