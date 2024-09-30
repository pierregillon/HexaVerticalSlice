using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Register.Ports;

public interface IPasswordHasher
{
    PasswordHash Hash(Password password);
}