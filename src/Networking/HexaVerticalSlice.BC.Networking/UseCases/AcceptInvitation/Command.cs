using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.Networking.CoreDomain.Invitations;

namespace HexaVerticalSlice.BC.Networking.UseCases.AcceptInvitation;

public record AcceptInvitationCommand(InvitationId InvitationId) : ICommand;