using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.Api.BuildingBlocks.Time;
using HexaVerticalSlice.BC.FeedComputation.Infra.Database;
using HexaVerticalSlice.BC.FeedComputation.Infra.Database.Models;
using HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost.Ports;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost;

public class PublishPostUseCase(
    FeedComputationDbContext dbContext,
    IProfileFinder profileFinder,
    IClock clock,
    ICurrentTenant currentTenant
) : IPublishPostUseCase
{
    public async Task PublishPost(string title, string content)
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