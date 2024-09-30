using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HexaVerticalSlice.Api.BuildingBlocks.Time;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain;
using HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Ports;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HexaVerticalSlice.BC.AccountManagement.Infra.TokenGeneration;

internal class JwtTokenGenerator(
    IOptions<JwtBearerTokenOptions> options,
    IClock clock
) : IJwtTokenGenerator, UseCases.Register.Ports.IJwtTokenGenerator
{
    private readonly JwtBearerTokenOptions _options = options.Value;

    public JwtToken Generate(UserAccountId userAccountId, string email)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userAccountId.Value.ToString()),
            new(ClaimTypes.Email, email),
            new(ClaimTypes.Name, email)
        };
        var token = GetToken(authClaims);
        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return new JwtToken(tokenValue, token.ValidTo);
    }

    private JwtSecurityToken GetToken(IEnumerable<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));

        return new JwtSecurityToken(
            _options.ValidIssuer,
            _options.ValidAudience,
            expires: clock.Now().Add(_options.Validity),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
    }
}