using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.Networking.Features.ListInvitations;

public record ListInvitationsQuery : IQuery<IReadOnlyCollection<InvitationDto>>;