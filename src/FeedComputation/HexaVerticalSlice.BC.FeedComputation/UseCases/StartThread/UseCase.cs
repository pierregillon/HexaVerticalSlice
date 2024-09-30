using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread;

public class StartThreadUseCase(
    IPostRepository postRepository,
    IThreadRepository threadRepository,
    IProfileFinder profileFinder
) : IStartThreadUseCase
{
    public async Task StartThread(ThreadId threadId, CommentDescription comment, PostId postId)
    {
        if (await threadRepository.AnyThreadForPost(threadId))
        {
            throw new InvalidOperationException("The thread already exists for this post.");
        }

        var profileId = await profileFinder.GetCurrentProfileId();

        var post = await postRepository.Get(postId);

        var thread = post.StartThread(threadId, comment, profileId);

        await threadRepository.Save(thread);
    }
}