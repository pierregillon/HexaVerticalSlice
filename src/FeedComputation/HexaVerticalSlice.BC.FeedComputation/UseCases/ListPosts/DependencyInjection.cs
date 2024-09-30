using HexaVerticalSlice.BC.FeedComputation.UseCases.ListPosts.Ports;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.ListPosts;

public static class DependencyInjection
{
    public static IServiceCollection AddListPostsUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IListPostsUseCase, ListPostsUseCase>();
}