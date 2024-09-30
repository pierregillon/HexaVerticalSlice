using System.IdentityModel.Tokens.Jwt;
using HexaVerticalSlice.Api.BuildingBlocks.Time;
using Microsoft.IdentityModel.Tokens;

namespace HexaVerticalSlice.Configuration.Authentication.Bearer;

internal class JwtSecurityTokenTimeValidator(IClock clock) : JwtSecurityTokenHandler
{
    protected override void ValidateLifetime(
        DateTime? notBefore,
        DateTime? expires,
        JwtSecurityToken jwtToken,
        TokenValidationParameters validationParameters
    )
    {
        if (notBefore is not null && clock.Now() < notBefore)
        {
            throw new Exception("The token is not valid yet.");
        }

        if (expires is not null && clock.Now() > expires)
        {
            throw new Exception("The token has expired.");
        }
    }
}