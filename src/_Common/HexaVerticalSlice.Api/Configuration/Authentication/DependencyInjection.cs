using System.Text;
using HexaVerticalSlice.BC.AccountManagement.Infra.TokenGeneration;
using HexaVerticalSlice.Configuration.Authentication.Bearer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HexaVerticalSlice.Configuration.Authentication;

internal static class DependencyInjection
{
    public static IServiceCollection AddAuthenticationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var jwtTokenOptions = configuration.Bind<JwtBearerTokenOptions>(JwtBearerTokenOptions.SectionName);

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtTokenOptions.ValidAudience,
                    ValidIssuer = jwtTokenOptions.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenOptions.Secret))
                };
            });

        services
            .AddTransient<IPostConfigureOptions<JwtBearerOptions>,
                ConfigureSecurityTokenValidatorPostConfigureJwtBearerOptions>();
        services.AddTransient<JwtSecurityTokenTimeValidator>();

        return services;
    }
}