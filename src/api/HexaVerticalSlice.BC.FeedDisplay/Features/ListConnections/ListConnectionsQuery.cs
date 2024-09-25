using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.FeedDisplay.Domain;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.ListConnections;

public record ListConnectionsQuery(ProfileId ProfileId) : IQuery<IReadOnlyCollection<ConnectionDto>>;