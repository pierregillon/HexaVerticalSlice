using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.FeedComputation.Steps;

[Binding]
public class CommentSteps(TestClient client)
{
    [When(@"I publish a comment ""(.*)"" on the ""(.*)"" post")]
    public async Task WhenIPublishACommentOnThePost(string comment, string postTitle)
    {
        var posts = await client.Get<IReadOnlyCollection<PostListItemDto>>("feed-computation/v1/posts/");

        var postId = posts.First(x => x.Title == postTitle).Id;

        await client.PostVoid($"feed-computation/v1/posts/{postId}/comments/", new
        {
            Id = Guid.NewGuid(),
            Comment = comment
        });
    }
}