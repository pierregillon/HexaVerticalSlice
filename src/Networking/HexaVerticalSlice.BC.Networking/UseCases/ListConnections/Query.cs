using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;

namespace HexaVerticalSlice.BC.Networking.UseCases.ListConnections;

public record ListConnectionsQuery(ProfileId ProfileId) : IQuery<IReadOnlyCollection<ConnectionDto>>;