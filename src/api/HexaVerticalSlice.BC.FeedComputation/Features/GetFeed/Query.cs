using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.Feeds.Features.GetFeed;

public record GetFeedQuery : IQuery<FeedDto>;