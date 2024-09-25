using FluentAssertions;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using Reqnroll;

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
}

public record FeedDto(IReadOnlyCollection<FeedDto.PostDto> Posts)
{
    public record PostDto(string Title, string Content);
}