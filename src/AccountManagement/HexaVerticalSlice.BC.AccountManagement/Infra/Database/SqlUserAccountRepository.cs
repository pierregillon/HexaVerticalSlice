using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain;

namespace HexaVerticalSlice.BC.AccountManagement.Infra.Database;

internal class SqlUserAccountRepository(AccountManagementDbContext dbContext, IDomainEventPublisher publisher)
    : IUserAccountRepository
{
    public async Task Save(UserAccount userAccount)
    {
        var entity = await dbContext.Users.FindAsync((Guid)userAccount.AccountId);
        if (entity is not null)
        {
            throw new NotImplementedException("Cannot update an existing user");
        }

        await dbContext.Users.AddAsync(new UserAccountEntity
        {
            Id = userAccount.AccountId,
            EmailAddress = userAccount.EmailAddress,
            PasswordHash = userAccount.PasswordHash
        });

        await publisher.Publish(userAccount.UncommittedChanges);

        userAccount.MarkAsCommitted();
    }
}