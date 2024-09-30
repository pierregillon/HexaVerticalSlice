using HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost.Adapters;
using HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost.Ports;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost;

public static class DependencyInjection
{
    public static IServiceCollection AddSendPostUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IPublishPostUseCase, PublishPostUseCase>()
            .AddTransient<IProfileFinder, FromNetworkingBoundedContextProfileFinder>();
}