using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.Networking.Domain.Profiles;

namespace HexaVerticalSlice.BC.Networking.Features.ListConnections;

public record ListConnectionsQuery(ProfileId ProfileId) : IQuery<IReadOnlyCollection<ConnectionDto>>;