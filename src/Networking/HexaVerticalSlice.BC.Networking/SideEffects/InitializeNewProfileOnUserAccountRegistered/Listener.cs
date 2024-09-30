using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.AccountManagement.Contracts;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;
using HexaVerticalSlice.BC.Networking.Infra.Database;

namespace HexaVerticalSlice.BC.Networking.SideEffects.InitializeNewProfileOnUserAccountRegistered;

public class Listener(IProfileRepository repository, NetworkingDbContext dbContext)
    : IIntegrationEventListener<UserAccountRegisteredIntegrationEvent>
{
    public async Task On(UserAccountRegisteredIntegrationEvent integrationEvent)
    {
        var profile = Profile.Initialize(integrationEvent.UserAccountId, integrationEvent.EmailAddress);

        await repository.Save(profile);

        await dbContext.SaveChangesAsync();
    }
}