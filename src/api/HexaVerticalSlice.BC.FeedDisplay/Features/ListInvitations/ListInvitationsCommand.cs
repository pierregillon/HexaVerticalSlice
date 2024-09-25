using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.ListInvitations;

public record ListInvitationsQuery : IQuery<IReadOnlyCollection<InvitationDto>>;