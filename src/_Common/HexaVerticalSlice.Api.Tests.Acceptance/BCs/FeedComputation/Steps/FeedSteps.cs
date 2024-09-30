using FluentAssertions;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using Reqnroll;
using Reqnroll.Assist;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.FeedComputation.Steps;

[Binding]
public class FeedSteps(TestClient client)
{
    private FeedDto? _feed;

    [When(@"I get my feed")]
    public async Task WhenIGetMyFeed() =>
        _feed = await client.Get<FeedDto>("feed-computation/v1/feed");

    [Then(@"the feed is empty")]
    public void ThenTheFeedIsEmpty()
    {
        _feed.Should().NotBeNull();
        _feed!.Posts.Should().BeEmpty();
    }

    [Then(@"my feed contains the following posts:")]
    public void ThenMyFeedContainsTheFollowingPosts(Table table)
    {
        _feed.Should().NotBeNull();

        var posts = _feed!.Posts
            .Select(x => new { Author = x.Author.EmailAddress, Date = x.PublishDate, x.Title, x.Content })
            .ToList();

        var expected = table.ToProjectionOfSet(posts).ToList();

        posts
            .ToProjection()
            .Should()
            .BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }
}

public record FeedDto(IReadOnlyCollection<FeedDto.PostDto> Posts)
{
    public record PostDto(string Title, DateTime PublishDate, AuthorDto Author, string Content);

    public record AuthorDto(string EmailAddress);
}