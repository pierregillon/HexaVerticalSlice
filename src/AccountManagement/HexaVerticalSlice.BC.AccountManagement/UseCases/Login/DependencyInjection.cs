using HexaVerticalSlice.BC.AccountManagement.Infra.TokenGeneration;
using HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Adapters;
using HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Ports;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login;

public static class DependencyInjection
{
    public static IServiceCollection AddLoginUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IUserFinder, FromDatabaseUserFinder>()
            .AddTransient<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddTransient<IPasswordHashVerifier, AspNetCoreIdentityPasswordHashVerifier>();
}