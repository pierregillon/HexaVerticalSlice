using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.AccountManagement.Domain;
using HexaVerticalSlice.BC.AccountManagement.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.AccountManagement.Features.AccountExists;

public record UserExistsQuery(UserAccountId UserAccountId) : IQuery<bool>
{
    internal record UserExistsQueryHandler(AccountManagementDbContext dbContext)
        : IQueryHandler<UserExistsQuery, bool>
    {
        public Task<bool> Handle(UserExistsQuery query) =>
            dbContext.Users.AnyAsync(x => x.Id == query.UserAccountId);
    }
}

