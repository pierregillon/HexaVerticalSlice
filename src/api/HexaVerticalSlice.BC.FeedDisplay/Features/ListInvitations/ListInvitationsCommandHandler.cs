using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.FeedDisplay.Infra;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.ListInvitations;

public class ListInvitationsCommandHandler(ICurrentTenant currentTenant, FeedDisplayDbContext dbContext)
    : IQueryHandler<ListInvitationsCommand, IReadOnlyCollection<InvitationDto>>
{
    public async Task<IReadOnlyCollection<InvitationDto>> Handle(ListInvitationsCommand query)
    {
        var sqlQuery =
            from invitation in dbContext.Invitations
            join sender in dbContext.Profiles on invitation.SenderId equals sender.Id
            join target in dbContext.Profiles on invitation.TargetId equals target.Id
            where sender.UserAccountId == currentTenant.GetCurrentUserId().Value
            select new InvitationDto(
                invitation.Id,
                new InvitationDto.ProfileDto(target.Id, target.EmailAddress),
                invitation.RequestDate
            );

        return await sqlQuery.ToListAsync();
    }
}