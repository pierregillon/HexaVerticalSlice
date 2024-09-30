using HexaVerticalSlice.Api.BuildingBlocks.Time;
using HexaVerticalSlice.BC.FeedComputation.Infra.Database;
using HexaVerticalSlice.BC.FeedComputation.Infra.Database.Models;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;
using Microsoft.EntityFrameworkCore;
using Thread = HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain.Thread;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Adapters;

public class SqlThreadRepository(FeedComputationDbContext dbContext, IClock clock) : IThreadRepository
{
    public async Task<bool> AnyThreadForPost(ThreadId threadId) =>
        await dbContext.Threads.AnyAsync(x => x.Id == threadId.Value);

    public async Task Save(Thread thread)
    {
        var entity = new ThreadEntity
        {
            Id = thread.Id.Value,
            PostId = thread.PostId.Value,
            Comments = new List<CommentEntity>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    ThreadId = thread.Id.Value,
                    Description = thread.Comment.Value,
                    PublishDate = clock.Now(),
                    ProfileId = thread.ProfileId
                }
            }
        };
        await dbContext.Threads.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }
}