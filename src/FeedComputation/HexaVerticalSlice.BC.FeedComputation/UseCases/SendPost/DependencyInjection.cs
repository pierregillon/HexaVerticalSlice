using HexaVerticalSlice.BC.Feeds.UseCases.SendPost.Adapters;
using HexaVerticalSlice.BC.Feeds.UseCases.SendPost.Ports;

namespace HexaVerticalSlice.BC.Feeds.UseCases.SendPost;

public static class DependencyInjection
{
    public static IServiceCollection AddSendPostUseCase(this IServiceCollection services) =>
        services
            .AddTransient<ISendPostUseCase, SendPostUseCase>()
            .AddTransient<IProfileFinder, FromNetworkingBoundedContextProfileFinder>();
}