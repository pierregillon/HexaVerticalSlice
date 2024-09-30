using HexaVerticalSlice.Api.Tests.Acceptance.BCs.AccountManagement.Steps;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.FeedComputation.Steps;

[Binding]
public class PostsSteps(TestClient client, UserAccountSteps userAccountSteps)
{
    [When(@"(.*) posts a post with title ""(.*)"" and content ""(.*)""")]
    public async Task WhenEmmaCompanyComPostsAPostWithTitleAndContent(
        string emailAddress,
        string title,
        string content
    ) =>
        await userAccountSteps.ExecuteTemporaryWithUser(emailAddress,
            async () =>
            {
                await client.PostVoid("feed-computation/v1/posts/", new
                {
                    Title = title,
                    Content = content
                });
            });
}