using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.AcceptInvitation;

public record AcceptInvitationCommand(InvitationId InvitationId) : ICommand;