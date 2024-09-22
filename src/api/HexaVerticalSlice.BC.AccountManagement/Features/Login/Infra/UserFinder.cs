using HexaVerticalSlice.BC.AccountManagement.Domain;
using HexaVerticalSlice.BC.AccountManagement.Domain.Security;
using HexaVerticalSlice.BC.AccountManagement.Features.Login.Core;
using HexaVerticalSlice.BC.AccountManagement.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login.Infra;

internal class FromDatabaseUserFinder(AccountManagementDbContext dbContext) : IUserFinder
{
    public async Task<UserDto?> Find(EmailAddress emailAddress) =>
        await dbContext.Users
            .Select(x => new UserDto(
                UserAccountId.Rehydrate(x.Id),
                x.EmailAddress,
                PasswordHash.Create(x.PasswordHash)
            ))
            .FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);
}
