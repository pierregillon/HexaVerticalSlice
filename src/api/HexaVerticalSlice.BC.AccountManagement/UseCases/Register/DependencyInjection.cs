using HexaVerticalSlice.BC.AccountManagement.Infra.Hasher;
using HexaVerticalSlice.BC.AccountManagement.Infra.TokenGeneration;
using HexaVerticalSlice.BC.AccountManagement.UseCases.Register.Ports;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Register;

public static class DependencyInjection
{
    public static IServiceCollection AddRegisterUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IPasswordHasher, AspNetCoreIdentityPasswordHasher>()
            .AddTransient<IJwtTokenGenerator, JwtTokenGenerator>()
            ;
}
