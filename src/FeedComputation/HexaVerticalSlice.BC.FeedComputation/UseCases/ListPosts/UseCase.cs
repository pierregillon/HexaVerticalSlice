using HexaVerticalSlice.BC.FeedComputation.Infra.Database;
using HexaVerticalSlice.BC.FeedComputation.UseCases.ListPosts.Ports;
using Microsoft.EntityFrameworkCore;

//TODO : rename namespace
namespace HexaVerticalSlice.BC.FeedComputation.UseCases.ListPosts;

public class ListPostsUseCase(FeedComputationDbContext dbContext) : IListPostsUseCase
{
    public async Task<IReadOnlyCollection<PostListItemDto>> ListPosts() =>
        await dbContext.Posts
            .Select(x => new PostListItemDto(x.Id, x.Title))
            .ToListAsync();
}