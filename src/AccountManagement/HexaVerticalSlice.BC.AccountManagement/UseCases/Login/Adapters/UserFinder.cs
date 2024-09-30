using HexaVerticalSlice.BC.AccountManagement.CoreDomain;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;
using HexaVerticalSlice.BC.AccountManagement.Infra.Database;
using HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Ports;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Adapters;

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