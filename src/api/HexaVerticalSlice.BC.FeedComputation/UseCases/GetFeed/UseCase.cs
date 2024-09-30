using HexaVerticalSlice.BC.Feeds.Infra.Database;
using HexaVerticalSlice.BC.Networking.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.Feeds.UseCases.GetFeed;

public class GetFeedUseCase(FeedComputationDbContext dbContext, IProfileFinder profileFinder)
{
    public async Task<FeedDto> Execute()
    {
        var query =
            from post in dbContext.Posts
            join connection in dbContext.Connections on post.UserId equals connection.UserId
            orderby post.PublishDate descending
            select new
            {
                connection.ProfileId,
                post.PublishDate,
                post.Title,
                post.Content,
                post.Id
            };

        var results = await query.Take(5).ToListAsync();

        var profileIds = results.Distinct().Select(x => x.ProfileId);

        var profileDetails = (await profileFinder.GetDetails(profileIds)).ToDictionary(x => x.Id);

        var posts = results
            .Select(x => new FeedDto.PostDto(
                x.Id,
                x.Title,
                x.PublishDate,
                x.Content,
                new FeedDto.AuthorDto(profileDetails[x.ProfileId].EmailAddress)
            ))
            .ToList();

        return new FeedDto(posts);
    }
}