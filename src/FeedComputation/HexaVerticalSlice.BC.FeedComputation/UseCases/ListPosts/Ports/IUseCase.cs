namespace HexaVerticalSlice.BC.FeedComputation.UseCases.ListPosts.Ports;

public interface IListPostsUseCase
{
    public Task<IReadOnlyCollection<PostListItemDto>> ListPosts();
}