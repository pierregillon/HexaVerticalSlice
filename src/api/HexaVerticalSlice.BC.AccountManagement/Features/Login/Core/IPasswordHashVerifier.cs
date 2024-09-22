using HexaVerticalSlice.BC.AccountManagement.Domain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login.Core;

public interface IPasswordHashVerifier
{
    bool Verify(UnverifiedPassword password, PasswordHash passwordHash);
}
