using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.Networking.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.Networking.UseCases.ListInvitations;

public class ListInvitationsQueryHandler(ICurrentTenant currentTenant, NetworkingDbContext dbContext)
    : IQueryHandler<ListInvitationsQuery, IReadOnlyCollection<InvitationDto>>
{
    public async Task<IReadOnlyCollection<InvitationDto>> Handle(ListInvitationsQuery query)
    {
        var sqlQuery =
            from invitation in dbContext.Invitations
            join sender in dbContext.Profiles on invitation.SenderId equals sender.Id
            join target in dbContext.Profiles on invitation.TargetId equals target.Id
            where sender.UserAccountId == currentTenant.GetCurrentUserId().Value
            where invitation.IsAccepted == false
            select new InvitationDto(
                invitation.Id,
                new InvitationDto.ProfileDto(target.Id, target.EmailAddress),
                invitation.RequestDate
            );

        return await sqlQuery.ToListAsync();
    }
}