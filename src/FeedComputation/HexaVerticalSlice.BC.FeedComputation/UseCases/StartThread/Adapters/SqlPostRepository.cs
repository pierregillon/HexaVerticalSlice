using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;
using HexaVerticalSlice.BC.FeedComputation.Infra.Database;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Adapters;

public class SqlPostRepository(FeedComputationDbContext dbContext) : IPostRepository
{
    public async Task<Post> Get(PostId postId)
    {
        var entity = await dbContext.Posts.FindAsync(postId.Value);

        if (entity is null)
        {
            throw new NotFoundException($"The post with id '{postId.Value}' could not be found.");
        }

        return new Post(PostId.Rehydrate(entity.Id));
    }
}