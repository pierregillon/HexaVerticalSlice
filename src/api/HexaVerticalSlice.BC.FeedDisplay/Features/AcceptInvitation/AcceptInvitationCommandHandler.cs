using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.FeedDisplay.Domain;
using HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.AcceptInvitation;

public class AcceptInvitationCommandHandler(
    ICurrentTenant currentTenant,
    IProfileRepository profileRepository,
    IRepository<Invitation, InvitationId> invitationRepository
)
    : ICommandHandler<AcceptInvitationCommand>
{
    public async Task Handle(AcceptInvitationCommand command)
    {
        var invitation = await invitationRepository.Get(command.InvitationId);

        var target = await profileRepository.Get(currentTenant.GetCurrentUserId());

        if (invitation.TargetId != target.Id)
        {
            throw new InvalidOperationException("The invitation is not for the current user.");
        }

        invitation.Accept();

        await invitationRepository.Save(invitation);
    }
}