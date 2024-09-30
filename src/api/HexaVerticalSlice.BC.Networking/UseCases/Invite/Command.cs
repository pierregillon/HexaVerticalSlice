using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.BC.Networking.CoreDomain.Invitations;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;

namespace HexaVerticalSlice.BC.Networking.UseCases.Invite;

public record InviteCommand(ProfileId ProfileId) : ICommand<InvitationId>;