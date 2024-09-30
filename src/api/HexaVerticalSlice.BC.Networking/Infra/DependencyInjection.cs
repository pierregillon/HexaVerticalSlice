using HexaVerticalSlice.BC.Networking.Contracts;
using HexaVerticalSlice.BC.Networking.Domain.Invitations;
using HexaVerticalSlice.BC.Networking.Domain.Profiles;
using HexaVerticalSlice.BC.Networking.Infra.Database;
using HexaVerticalSlice.BC.Networking.Infra.Database.Repositories;
using HexaVerticalSlice.BC.Networking.Infra.ExternalAdapter;
using Microsoft.Extensions.Options;

namespace HexaVerticalSlice.BC.Networking.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
    {
        services
            .AddOptions<DatabaseConfiguration>()
            .BindConfiguration(DatabaseConfiguration.Section)
            .ValidateDataAnnotations()
            ;

        services
            .AddTransient<IProfileRepository, SqlProfileRepository>()
            .AddTransient<IInvitationRepository, SqlInvitationRepository>()
            .AddTransient<IProfileFinder, SqlProfileFinder>()
            .AddDbContext<NetworkingDbContext>((sp, options) =>
            {
                var configuration = sp.GetRequiredService<IOptions<DatabaseConfiguration>>();

                options.UseNpgsql(configuration);
            })
            ;

        return services;
    }
}