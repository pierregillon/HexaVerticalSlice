using HexaVerticalSlice.BC.AccountManagement.Infra.TokenGeneration;
using HexaVerticalSlice.BC.AccountManagement.Infra.Database;

namespace HexaVerticalSlice.BC.AccountManagement.Infra;

internal static class DependencyInjection
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
    {
        services
            .RegisterDatabaseInfrastructure()
            ;

        services
            .AddOptions<JwtBearerTokenOptions>()
            .BindConfiguration(JwtBearerTokenOptions.SectionName)
            .ValidateDataAnnotations();
        
        services.AddScoped<JwtTokenGenerator>();

        return services;
    }
}
