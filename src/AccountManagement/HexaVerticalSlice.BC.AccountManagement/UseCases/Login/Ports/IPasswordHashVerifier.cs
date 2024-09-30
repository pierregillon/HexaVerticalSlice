using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Ports;

public interface IPasswordHashVerifier
{
    bool Verify(UnverifiedPassword password, PasswordHash passwordHash);
}