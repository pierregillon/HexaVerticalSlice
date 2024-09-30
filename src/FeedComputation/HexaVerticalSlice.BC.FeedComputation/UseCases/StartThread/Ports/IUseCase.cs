using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;

public interface IStartThreadUseCase
{
    Task StartThread(ThreadId threadId, CommentDescription description, PostId postId);
}