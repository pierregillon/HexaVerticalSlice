using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.FeedDisplay.Domain;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

public record InviteCommand(ProfileId ProfileId) : ICommand<InvitationId>;