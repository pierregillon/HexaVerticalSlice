namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;

public class Thread
{
    public ThreadId Id { get; }
    public CommentDescription Comment { get; }
    public PostId PostId { get; }
    public Guid ProfileId { get; }

    private Thread(ThreadId id, CommentDescription comment, PostId postId, Guid profileId)
    {
        Id = id;
        Comment = comment;
        PostId = postId;
        ProfileId = profileId;
    }

    public static Thread Start(ThreadId id, CommentDescription comment, PostId postId, Guid profileId) =>
        new(id, comment, postId, profileId);
}