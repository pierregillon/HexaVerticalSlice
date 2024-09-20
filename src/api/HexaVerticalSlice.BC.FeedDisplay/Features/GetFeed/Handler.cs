using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.GetFeed;

public class GetFeedQueryHandler() : IQueryHandler<GetFeedQuery, FeedDto>
{
    public async Task<FeedDto> Handle(GetFeedQuery request)
    {
        return new FeedDto(new List<FeedDto.PostDto>());
    }
}