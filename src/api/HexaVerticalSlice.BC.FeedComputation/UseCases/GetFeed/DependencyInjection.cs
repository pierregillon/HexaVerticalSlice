namespace HexaVerticalSlice.BC.Feeds.UseCases.GetFeed;

public static class DependencyInjection
{
    public static IServiceCollection AddGetFeedUseCase(this IServiceCollection services) =>
        services
            .AddTransient<GetFeedUseCase>();
}