using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;
using Thread = HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain.Thread;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;

public interface IThreadRepository
{
    Task<bool> AnyThreadForPost(ThreadId threadId);
    Task Save(Thread thread);
}