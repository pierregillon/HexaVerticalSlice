using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.Networking.Domain.Profiles;

namespace HexaVerticalSlice.BC.Networking.Domain.Invitations;

public record InvitationAccepted(InvitationId Id, ProfileId SenderId, ProfileId TargetId) : IDomainEvent;