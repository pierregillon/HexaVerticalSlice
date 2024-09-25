using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.AccountManagement.Contracts;
using HexaVerticalSlice.BC.FeedDisplay.Domain;
using HexaVerticalSlice.BC.FeedDisplay.Features.SearchForProfile;
using HexaVerticalSlice.BC.FeedDisplay.Infra;

namespace HexaVerticalSlice.BC.FeedDisplay.SideEffects.CreateNewProfileOnUserAccountRegistered;

public class Listener(IRepository<Profile, ProfileId> repository, FeedDisplayDbContext dbContext)
    : IIntegrationEventListener<UserAccountRegisteredIntegrationEvent>
{
    public async Task On(UserAccountRegisteredIntegrationEvent domainEvent)
    {
        var profile = Profile.Initialize(domainEvent.UserAccountId, domainEvent.EmailAddress);

        await repository.Save(profile);

        await dbContext.SaveChangesAsync();
    }
}