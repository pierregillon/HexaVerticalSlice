using HexaVerticalSlice.BC.Feeds.UseCases.GetFeed;
using HexaVerticalSlice.BC.Feeds.UseCases.PublishPost;

namespace HexaVerticalSlice.BC.Feeds.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services
            .AddGetFeedUseCase()
            .AddSendPostUseCase()
            ;

        return services;
    }
}