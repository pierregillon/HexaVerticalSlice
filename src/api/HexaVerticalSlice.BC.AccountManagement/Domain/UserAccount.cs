using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.BC.AccountManagement.Domain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.Domain;

public class UserAccount : AggregateRoot<UserAccountId>
{
    private UserAccount(
        UserAccountId accountId,
        EmailAddress emailAddress,
        PasswordHash passwordHashHash) : base(accountId)
    {
        EmailAddress = emailAddress;
        PasswordHash = passwordHashHash;
    }

    public EmailAddress EmailAddress { get; }
    public PasswordHash PasswordHash { get; }

    public static UserAccount Register(
        EmailAddress emailAddress,
        PasswordHash passwordHash
    )
    {
        var user = new UserAccount(
            UserAccountId.New(),
            emailAddress,
            passwordHash
        );
        user.ApplyEvent(new UserAccountRegistered(user.AccountId, emailAddress, passwordHash));
        return user;
    }

    public static UserAccount Rehydrate(
        UserAccountId accountId,
        EmailAddress emailAddress,
        PasswordHash passwordHash) =>
        new(accountId, emailAddress, passwordHash);
}
