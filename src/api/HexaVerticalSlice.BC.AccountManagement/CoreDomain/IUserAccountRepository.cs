namespace HexaVerticalSlice.BC.AccountManagement.CoreDomain;

public interface IUserAccountRepository
{
    Task Save(UserAccount userAccount);
}