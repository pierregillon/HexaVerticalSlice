using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.Networking.Domain.Invitations;
using HexaVerticalSlice.BC.Networking.Domain.Profiles;

namespace HexaVerticalSlice.BC.Networking.Features.Invite;

public record InviteCommand(ProfileId ProfileId) : ICommand<InvitationId>;