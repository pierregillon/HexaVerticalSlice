using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.FeedDisplay.Infra;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.ListConnections;

public class ListConnectionsQueryHandler(FeedDisplayDbContext dbContext)
    : IQueryHandler<ListConnectionsQuery, IReadOnlyCollection<ConnectionDto>>
{
    public async Task<IReadOnlyCollection<ConnectionDto>> Handle(ListConnectionsQuery query)
    {
        var sqlQuery =
            from profile in dbContext.Profiles
            join connection in dbContext.Connections on profile.Id equals connection.ProfileId
            join connectedProfile in dbContext.Profiles on connection.ConnectedProfileId equals connectedProfile.Id
            where profile.Id == query.ProfileId.Value
            select new ConnectionDto(
                new ConnectionDto.ProfileDto(connectedProfile.Id, connectedProfile.EmailAddress),
                connection.AddedDate
            );

        return await sqlQuery.ToListAsync();
    }
}