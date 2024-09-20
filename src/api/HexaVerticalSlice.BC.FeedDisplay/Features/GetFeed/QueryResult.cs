namespace HexaVerticalSlice.BC.FeedDisplay.Features.GetFeed;

public record FeedDto(IReadOnlyCollection<FeedDto.PostDto> Posts)
{
    public record PostDto(Guid Id, string Title, string Content);
}