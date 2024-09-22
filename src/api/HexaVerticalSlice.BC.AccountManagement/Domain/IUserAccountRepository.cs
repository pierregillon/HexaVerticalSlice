namespace HexaVerticalSlice.BC.AccountManagement.Domain;

public interface IUserAccountRepository
{
    Task Save(UserAccount userAccount);
}
