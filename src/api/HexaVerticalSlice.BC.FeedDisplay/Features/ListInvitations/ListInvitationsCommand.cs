using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.ListInvitations;

public record ListInvitationsCommand : IQuery<IReadOnlyCollection<InvitationDto>>;