using HexaVerticalSlice.BC.AccountManagement.CoreDomain;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Register.Ports;

public interface IJwtTokenGenerator
{
    JwtToken Generate(UserAccountId userAccountId, string emailAddress);
}
