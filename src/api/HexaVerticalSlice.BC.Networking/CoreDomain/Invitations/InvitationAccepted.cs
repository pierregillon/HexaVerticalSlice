using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;

namespace HexaVerticalSlice.BC.Networking.CoreDomain.Invitations;

public record InvitationAccepted(InvitationId Id, ProfileId SenderId, ProfileId TargetId) : IDomainEvent;