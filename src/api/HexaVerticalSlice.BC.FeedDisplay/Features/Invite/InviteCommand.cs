using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.FeedDisplay.Features.SearchForProfile;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

public record InviteCommand(ProfileId ProfileId) : ICommand;