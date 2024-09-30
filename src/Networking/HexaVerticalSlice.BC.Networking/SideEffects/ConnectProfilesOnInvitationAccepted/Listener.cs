using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.Networking.CoreDomain.Invitations;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;

namespace HexaVerticalSlice.BC.Networking.SideEffects.ConnectProfilesOnInvitationAccepted;

public class Listener(IProfileRepository repository)
    : IDomainEventListener<InvitationAccepted>
{
    public async Task On(InvitationAccepted domainEvent)
    {
        var sender = await repository.Get(domainEvent.SenderId);
        var target = await repository.Get(domainEvent.TargetId);

        // TODO: create domain service
        sender.ConnectTo(target.Id);
        target.ConnectTo(sender.Id);

        await repository.Save(sender, target);
    }
}