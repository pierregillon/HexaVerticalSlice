using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.Networking.Domain.Invitations;
using HexaVerticalSlice.BC.Networking.Domain.Profiles;

namespace HexaVerticalSlice.BC.Networking.SideEffects.AddProfileConnectionOnInvitationAccepted;

public class Listener(IProfileRepository repository)
    : IDomainEventListener<InvitationAccepted>
{
    public async Task On(InvitationAccepted domainEvent)
    {
        var sender = await repository.Get(domainEvent.SenderId);
        var target = await repository.Get(domainEvent.TargetId);

        sender.AddConnection(target.Id);
        target.AddConnection(sender.Id);

        await repository.Save(sender, target);
    }
}