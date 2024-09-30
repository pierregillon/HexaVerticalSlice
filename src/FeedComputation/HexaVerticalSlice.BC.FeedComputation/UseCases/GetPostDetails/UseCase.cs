using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;
using HexaVerticalSlice.BC.FeedComputation.Infra.Database;
using HexaVerticalSlice.BC.FeedComputation.UseCases.GetPostDetails.Ports;
using HexaVerticalSlice.BC.Networking.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.GetPostDetails;

public class GetPostDetailsUseCase(FeedComputationDbContext dbContext, IProfileFinder profileFinder)
    : IGetPostDetailsUseCase
{
    public async Task<PostDetailsDto> GetDetails(Guid postId)
    {
        var post = await dbContext.Posts
            .Include(x => x.Threads)
            .ThenInclude(x => x.Comments) // HACK : shortcut, careful, not optimized we take only the first comment
            .FirstOrDefaultAsync(x => x.Id == postId);

        if (post is null)
        {
            throw new NotFoundException("The post could not be found.");
        }

        var profileIds = post.Threads.Select(x => x.Comments.First().ProfileId);

        var profileDetails = (await profileFinder.GetDetails(profileIds)).ToDictionary(x => x.Id);

        return new PostDetailsDto(
            post.Id,
            post.Title,
            post.Content,
            post.Threads
                .Select(x =>
                    new PostDetailsDto.ThreadDto(
                        x.Id,
                        new PostDetailsDto.CommentDto(
                            profileDetails[x.Comments.First().ProfileId].EmailAddress,
                            x.Comments.First().Description,
                            x.Comments.First().PublishDate
                        )
                    )
                ).ToList()
        );
    }
}