using FluentAssertions;
using HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Utils;
using Reqnroll;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Steps;

[Binding]
public class FeedSteps(TestClient client)
{
    private FeedDto? _feed;

    [When(@"I get my feed")]
    public async Task WhenIGetMyFeed()
    {
        _feed = await client.Get<FeedDto>("feed-display/v1/feed");
    }

    [Then(@"the feed is empty")]
    public void ThenTheFeedIsEmpty()
    {
        _feed.Should().NotBeNull();
        _feed!.Posts.Should().BeEmpty();
    }
}

public record FeedDto(IReadOnlyCollection<FeedDto.PostDto> Posts)
{
    public record PostDto(string Title, string Content);
}