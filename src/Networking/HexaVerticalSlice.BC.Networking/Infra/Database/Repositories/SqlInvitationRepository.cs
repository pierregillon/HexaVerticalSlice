using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;
using HexaVerticalSlice.BC.Networking.CoreDomain.Invitations;
using HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;
using HexaVerticalSlice.BC.Networking.Infra.Database.Models;

namespace HexaVerticalSlice.BC.Networking.Infra.Database.Repositories;

public class SqlInvitationRepository(NetworkingDbContext dbContext, IDomainEventPublisher publisher)
    : IInvitationRepository
{
    public async Task<Invitation> Get(InvitationId id)
    {
        var entity = await dbContext.Invitations.FindAsync(id.Value);

        return entity is null
            ? throw new NotFoundException($"The invitation with id '{id.Value}' could not be found.")
            : Rehydrate(entity);
    }

    public async Task Save(Invitation invitation)
    {
        var entity = await dbContext.Invitations.FindAsync(invitation.Id.Value);

        if (entity is null)
        {
            entity = new InvitationEntity
            {
                Id = invitation.Id.Value,
                SenderId = invitation.SenderId.Value,
                TargetId = invitation.TargetId.Value,
                RequestDate = invitation.RequestDate,
                IsAccepted = invitation.IsAccepted
            };
            dbContext.Invitations.Add(entity);
        }
        else
        {
            entity.SenderId = invitation.SenderId.Value;
            entity.TargetId = invitation.TargetId.Value;
            entity.RequestDate = invitation.RequestDate;
            entity.IsAccepted = invitation.IsAccepted;
        }

        await publisher.Publish(invitation.UncommittedChanges);

        invitation.MarkAsCommitted();
    }

    private Invitation Rehydrate(InvitationEntity entity) =>
        Invitation.Rehydrate(
            new InvitationId(entity.Id),
            new ProfileId(entity.SenderId),
            new ProfileId(entity.TargetId),
            entity.RequestDate
        );
}