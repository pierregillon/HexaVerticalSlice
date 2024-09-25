using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.Api.BuildingBlocks.Time;
using HexaVerticalSlice.BC.FeedDisplay.Domain;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

public class InviteCommandHandler(
    ICurrentTenant currentTenant,
    IProfileRepository profileRepository,
    IRepository<Invitation, InvitationId> invitationRepository,
    IClock clock
)
    : ICommandHandler<InviteCommand>
{
    public async Task Handle(InviteCommand command)
    {
        var sender = await profileRepository.Get(currentTenant.GetCurrentUserId());
        var target = await profileRepository.Get(command.ProfileId);

        var invitation = sender.Invite(target, clock.Now());

        await invitationRepository.Save(invitation);
    }
}