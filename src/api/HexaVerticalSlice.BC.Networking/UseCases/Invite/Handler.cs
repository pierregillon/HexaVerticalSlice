using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.Api.BuildingBlocks.Time;
using HexaVerticalSlice.BC.Networking.CoreDomain.Invitations;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;

namespace HexaVerticalSlice.BC.Networking.UseCases.Invite;

public class InviteCommandHandler(
    ICurrentTenant currentTenant,
    IProfileRepository profileRepository,
    IInvitationRepository invitationRepository,
    IClock clock
) : ICommandHandler<InviteCommand, InvitationId>
{
    public async Task<InvitationId> Handle(InviteCommand command)
    {
        var sender = await profileRepository.Get(currentTenant.GetCurrentUserId());
        var target = await profileRepository.Get(command.ProfileId);

        var invitation = sender.Invite(target, clock.Now());

        await invitationRepository.Save(invitation);

        return invitation.Id;
    }
}