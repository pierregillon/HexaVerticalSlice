using HexaVerticalSlice.BC.AccountManagement.Features.Login.Core;
using HexaVerticalSlice.BC.AccountManagement.Features.Login.Infra;
using HexaVerticalSlice.BC.AccountManagement.Infra.Hasher;
using HexaVerticalSlice.BC.AccountManagement.Infra.TokenGeneration;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login;

public static class DependencyInjection
{
    public static IServiceCollection AddLoginUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IUserFinder, FromDatabaseUserFinder>()
            .AddTransient<IJwtTokenGenerator, JwtTokenGenerator>()
            .AddTransient<IPasswordHashVerifier, AspNetCoreIdentityPasswordHasher>();
}
