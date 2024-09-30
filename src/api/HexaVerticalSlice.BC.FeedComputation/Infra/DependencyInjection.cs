using HexaVerticalSlice.BC.Feeds.Infra.Database;
using Microsoft.Extensions.Options;

namespace HexaVerticalSlice.BC.Feeds.Infra;

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
            .AddDbContext<FeedComputationDbContext>((sp, options) =>
            {
                var configuration = sp.GetRequiredService<IOptions<DatabaseConfiguration>>();

                options.UseNpgsql(configuration);
            })
            ;

        return services;
    }
}