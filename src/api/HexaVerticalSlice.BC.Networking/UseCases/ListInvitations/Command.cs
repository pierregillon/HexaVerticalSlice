using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.Networking.UseCases.ListInvitations;

public record ListInvitationsQuery : IQuery<IReadOnlyCollection<InvitationDto>>;