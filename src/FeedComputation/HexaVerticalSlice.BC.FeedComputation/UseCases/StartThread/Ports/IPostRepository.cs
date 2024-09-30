using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;

public interface IPostRepository
{
    Task<Post> Get(PostId postId);
}