namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;

public class Post(PostId id)
{
    public Thread StartThread(ThreadId threadId, CommentDescription description, Guid profileId) =>
        Thread.Start(threadId, description, id, profileId);
}