using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.Networking.Domain.Invitations;

namespace HexaVerticalSlice.BC.Networking.Features.AcceptInvitation;

public record AcceptInvitationCommand(InvitationId InvitationId) : ICommand;