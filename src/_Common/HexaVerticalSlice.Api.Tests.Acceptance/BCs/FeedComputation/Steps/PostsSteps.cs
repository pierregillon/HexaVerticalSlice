using FluentAssertions;
using HexaVerticalSlice.Api.Tests.Acceptance.BCs.AccountManagement.Steps;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using Reqnroll;
using Reqnroll.Assist;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.FeedComputation.Steps;

[Binding]
public class PostsSteps(TestClient client, UserAccountSteps userAccountSteps)
{
    private PostDetailsDto? _postDetails;

    [Given(@"a post with title ""(.*)"" and content ""(.*)"" has been published")]
    [When(@"I publish a post with title ""(.*)"" and content ""(.*)""")]
    public async Task WhenIPublishAPostWithTitleAndContent(string title, string content) =>
        await PublishPost(title, content);

    [When(@"(.*) publishes a post with title ""(.*)"" and content ""(.*)""")]
    public async Task WhenEmmaCompanyComPostsAPostWithTitleAndContent(
        string emailAddress,
        string title,
        string content
    ) =>
        await userAccountSteps.ExecuteTemporaryWithUser(emailAddress,
            async () => await PublishPost(title, content)
        );

    [When(@"I get the ""(.*)"" post details")]
    public async Task WhenIGetThePostDetails(string postTitle)
    {
        var posts = await client.Get<IReadOnlyCollection<PostListItemDto>>("feed-computation/v1/posts/");

        var postId = posts.First(x => x.Title == postTitle).Id;

        _postDetails = await client.Get<PostDetailsDto>($"feed-computation/v1/posts/{postId}");
    }

    [Then(@"the post has the following threads:")]
    public void ThenThePostHasTheFollowingThreads(Table table)
    {
        var query = _postDetails!.Threads
            .Select(x => new { x.FirstComment.Author, x.FirstComment.Comment, x.FirstComment.Date, x.CommentCount })
            .ToList();

        var expected = table.ToProjectionOfSet(query).ToList();

        query
            .ToProjection()
            .Should()
            .BeEquivalentTo(expected);
    }

    private async Task PublishPost(string title, string content) =>
        await client.PostVoid("feed-computation/v1/posts/", new
        {
            Title = title,
            Content = content
        });
}

public record PostDetailsDto(
    Guid Id,
    string Title,
    string Content,
    IReadOnlyCollection<PostDetailsDto.ThreadDto> Threads
)
{
    public record ThreadDto(Guid ThreadId, CommentDto FirstComment, int CommentCount);

    public record CommentDto(string Author, string Comment, DateTime Date);
}

public record PostListItemDto(Guid Id, string Title);