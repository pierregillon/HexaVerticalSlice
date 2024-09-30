using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.Feeds.Infra.Database;
using HexaVerticalSlice.BC.Feeds.Infra.Models;
using HexaVerticalSlice.BC.Networking.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.Feeds.SideEffects.AddContactOnProfileConnected;

public class Listener(FeedComputationDbContext dbContext) : IIntegrationEventListener<ProfileConnectedIntegrationEvent>
{
    public async Task On(ProfileConnectedIntegrationEvent integrationEvent)
    {
        var contact = await dbContext.Connections
            .FirstOrDefaultAsync(x =>
                x.UserId == integrationEvent.UserId && x.ConnectedUserId == integrationEvent.ConnectedUserId
            );

        if (contact is null)
        {
            await dbContext.Connections.AddAsync(
                new ConnectionEntity
                {
                    UserId = integrationEvent.UserId,
                    ProfileId = integrationEvent.ProfileId,
                    ConnectedUserId = integrationEvent.ConnectedUserId
                }
            );
        }
    }
}