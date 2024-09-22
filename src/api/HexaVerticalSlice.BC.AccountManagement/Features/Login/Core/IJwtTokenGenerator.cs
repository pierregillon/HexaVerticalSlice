using HexaVerticalSlice.BC.AccountManagement.Domain;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login.Core;

public interface IJwtTokenGenerator
{
    JwtToken Generate(UserAccountId userAccountId, string emailAddress);
}
