using HexaVerticalSlice.BC.FeedComputation.UseCases.GetFeed.Ports;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.GetFeed;

public static class DependencyInjection
{
    public static IServiceCollection AddGetFeedUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IGetFeedUseCase, GetFeedUseCase>();
}