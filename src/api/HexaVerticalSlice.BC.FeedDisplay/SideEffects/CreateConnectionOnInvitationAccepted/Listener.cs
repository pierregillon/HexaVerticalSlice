using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.FeedDisplay.Domain;
using HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

namespace HexaVerticalSlice.BC.FeedDisplay.SideEffects.CreateConnectionOnInvitationAccepted;

public class Listener(IRepository<Profile, ProfileId> repository)
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