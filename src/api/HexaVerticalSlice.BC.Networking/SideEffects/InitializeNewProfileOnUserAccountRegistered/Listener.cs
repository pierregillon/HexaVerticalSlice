using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.AccountManagement.Contracts;
using HexaVerticalSlice.BC.Networking.Domain.Profiles;
using HexaVerticalSlice.BC.Networking.Infra.Database;

namespace HexaVerticalSlice.BC.Networking.SideEffects.InitializeNewProfileOnUserAccountRegistered;

public class Listener(IProfileRepository repository, FeedDisplayDbContext dbContext)
    : IIntegrationEventListener<UserAccountRegisteredIntegrationEvent>
{
    public async Task On(UserAccountRegisteredIntegrationEvent domainEvent)
    {
        var profile = Profile.Initialize(domainEvent.UserAccountId, domainEvent.EmailAddress);

        await repository.Save(profile);

        await dbContext.SaveChangesAsync();
    }
}