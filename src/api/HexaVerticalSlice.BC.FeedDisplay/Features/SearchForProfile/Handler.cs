using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;
using HexaVerticalSlice.BC.FeedDisplay.Infra;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.SearchForProfile;

public class SearchForProfileGetProfileQueryHandler(FeedDisplayDbContext dbContext)
    : IQueryHandler<SearchForProfileQuery, ProfileDto>
{
    public async Task<ProfileDto> Handle(SearchForProfileQuery query)
    {
        var profileDetails = await dbContext.Profiles
            .Where(x => x.EmailAddress == query.EmailAddress)
            .Select(x => new ProfileDto(x.Id, x.EmailAddress))
            .FirstOrDefaultAsync();

        if (profileDetails is null)
        {
            throw new NotFoundException("The profile could not be found.");
        }

        return profileDetails;
    }
}