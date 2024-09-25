using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.FeedDisplay.Domain;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

public record InvitationAccepted(InvitationId Id, ProfileId SenderId, ProfileId TargetId) : IDomainEvent;