using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.GetFeed;

public record GetFeedQuery() : IQuery<FeedDto>;