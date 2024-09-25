using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.AccountManagement.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.AccountManagement.Features.AccountExists;

internal class UserExistsQueryHandler(AccountManagementDbContext dbContext)
    : IQueryHandler<UserAccountExistsQuery, bool>
{
    public Task<bool> Handle(UserAccountExistsQuery query) =>
        dbContext.Users.AnyAsync(x => x.Id == query.UserAccountId);
}