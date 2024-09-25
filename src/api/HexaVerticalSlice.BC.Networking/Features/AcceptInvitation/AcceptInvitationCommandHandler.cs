using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.Networking.Domain.Invitations;
using HexaVerticalSlice.BC.Networking.Domain.Profiles;

namespace HexaVerticalSlice.BC.Networking.Features.AcceptInvitation;

public class AcceptInvitationCommandHandler(
    ICurrentTenant currentTenant,
    IProfileRepository profileRepository,
    IInvitationRepository invitationRepository
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