namespace HexaVerticalSlice.BC.Feeds.UseCases.GetFeed;

public record FeedDto(IReadOnlyCollection<FeedDto.PostDto> Posts)
{
    public record PostDto(Guid Id, string Title, DateTime PublishDate, string Content, AuthorDto Author);

    public record AuthorDto(string EmailAddress);
}