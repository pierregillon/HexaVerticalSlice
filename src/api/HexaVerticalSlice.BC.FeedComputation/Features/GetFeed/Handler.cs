using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.Feeds.Features.GetFeed;

public class GetFeedQueryHandler : IQueryHandler<GetFeedQuery, FeedDto>
{
    public async Task<FeedDto> Handle(GetFeedQuery request) =>
        new(new List<FeedDto.PostDto>());
}