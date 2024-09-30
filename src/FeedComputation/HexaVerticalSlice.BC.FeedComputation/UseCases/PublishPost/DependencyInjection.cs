using HexaVerticalSlice.BC.Feeds.UseCases.PublishPost.Adapters;
using HexaVerticalSlice.BC.Feeds.UseCases.PublishPost.Ports;

namespace HexaVerticalSlice.BC.Feeds.UseCases.PublishPost;

public static class DependencyInjection
{
    public static IServiceCollection AddSendPostUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IPublishPostUseCase, PublishPostUseCase>()
            .AddTransient<IProfileFinder, FromNetworkingBoundedContextProfileFinder>();
}