namespace HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;

public record UnverifiedPassword(string Value)
{
    public static implicit operator string(UnverifiedPassword password) => password.Value;
}