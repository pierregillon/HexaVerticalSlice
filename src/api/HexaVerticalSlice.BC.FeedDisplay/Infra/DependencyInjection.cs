using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.BC.FeedDisplay.Domain;
using HexaVerticalSlice.BC.FeedDisplay.Features.Invite;
using HexaVerticalSlice.BC.FeedDisplay.Features.SearchForProfile;
using Microsoft.Extensions.Options;

namespace HexaVerticalSlice.BC.FeedDisplay.Infra;

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
            .AddTransient<IRepository<Profile, ProfileId>, SqlProfileRepository>()
            .AddTransient<IRepository<Invitation, InvitationId>, SqlInvitationRepository>()
            .AddDbContext<FeedDisplayDbContext>((sp, options) =>
            {
                var configuration = sp.GetRequiredService<IOptions<DatabaseConfiguration>>();

                options.UseNpgsql(configuration);
            })
            ;

        return services;
    }
}