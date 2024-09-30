using HexaVerticalSlice.BC.FeedComputation.UseCases.GetFeed;
using HexaVerticalSlice.BC.FeedComputation.UseCases.GetPostDetails;
using HexaVerticalSlice.BC.FeedComputation.UseCases.ListPosts;
using HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services
            .AddGetFeedUseCase()
            .AddSendPostUseCase()
            .AddListPostsUseCase()
            .AddGetPostDetailsUseCase()
            .AddStartThreadUseCase()
            ;

        return services;
    }
}