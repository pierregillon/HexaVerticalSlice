using HexaVerticalSlice.BC.Feeds.UseCases.GetFeed.Ports;

namespace HexaVerticalSlice.BC.Feeds.UseCases.GetFeed;

public static class DependencyInjection
{
    public static IServiceCollection AddGetFeedUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IGetFeedUseCase, GetFeedUseCase>();
}