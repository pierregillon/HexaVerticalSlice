using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Adapters;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread;

public static class DependencyInjection
{
    public static IServiceCollection AddStartThreadUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IStartThreadUseCase, StartThreadUseCase>()
            .AddTransient<IPostRepository, SqlPostRepository>()
            .AddTransient<IThreadRepository, SqlThreadRepository>()
            .AddTransient<IProfileFinder, FromNetworkingBoundedContextProfileFinder>();
}