using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace HexaVerticalSlice.Configuration.Authentication.Bearer;

internal class ConfigureSecurityTokenValidatorPostConfigureJwtBearerOptions(
    JwtSecurityTokenTimeValidator tokenTimeValidator
)
    : IPostConfigureOptions<JwtBearerOptions>
{
    public void PostConfigure(string? name, JwtBearerOptions options)
    {
        options.TokenHandlers.Clear();
        options.TokenHandlers.Add(tokenTimeValidator);
    }
}