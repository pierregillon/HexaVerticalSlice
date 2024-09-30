using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.Api.BuildingBlocks.Time;
using HexaVerticalSlice.BC.Feeds.Infra.Database;
using HexaVerticalSlice.BC.Feeds.Infra.Database.Models;

namespace HexaVerticalSlice.BC.Feeds.Features.SendPost;

public class SendPostUseCase(
    FeedComputationDbContext dbContext,
    IProfileFinder profileFinder,
    IClock clock,
    ICurrentTenant currentTenant
)
{
    public async Task SendPost(string title, string content)
    {
        var profileId = await profileFinder.GetCurrentProfileId();

        var post = new PostEntity
        {
            Id = Guid.NewGuid(),
            Title = title,
            Content = content,
            PublishDate = clock.Now(),
            ProfileId = profileId,
            UserId = currentTenant.GetCurrentUserId().Value
        };

        await dbContext.Posts.AddAsync(post);
        await dbContext.SaveChangesAsync();
    }
}