using HexaVerticalSlice.BC.AccountManagement.Domain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Register.Core;

public interface IPasswordHasher
{
    PasswordHash Hash(Password password);
}
