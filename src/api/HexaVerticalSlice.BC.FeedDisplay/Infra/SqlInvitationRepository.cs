using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

namespace HexaVerticalSlice.BC.FeedDisplay.Infra;

public class SqlInvitationRepository(FeedDisplayDbContext dbContext) : IRepository<Invitation, InvitationId>
{
    public Task<Invitation> Get(InvitationId id) =>
        throw new NotImplementedException();

    public Task Save(Invitation invitation)
    {
        var entity = new InvitationEntity
        {
            Id = invitation.Id.Value,
            SenderId = invitation.SenderId.Value,
            TargetId = invitation.TargetId.Value,
            RequestDate = invitation.RequestDate
        };
        dbContext.Invitations.Add(entity);
        return dbContext.SaveChangesAsync();
    }
}