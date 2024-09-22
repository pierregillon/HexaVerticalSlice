using HexaVerticalSlice.BC.AccountManagement.Features.Register.Core;
using HexaVerticalSlice.BC.AccountManagement.Infra.Hasher;
using HexaVerticalSlice.BC.AccountManagement.Infra.TokenGeneration;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Register;

public static class DependencyInjection
{
    public static IServiceCollection AddRegisterUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IPasswordHasher, AspNetCoreIdentityPasswordHasher>()
            .AddTransient<IJwtTokenGenerator, JwtTokenGenerator>()
            ;
}
