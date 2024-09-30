using HexaVerticalSlice.BC.FeedComputation.UseCases.GetPostDetails.Ports;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.GetPostDetails;

public static class DependencyInjection
{
    public static IServiceCollection AddGetPostDetailsUseCase(this IServiceCollection services) =>
        services
            .AddTransient<IGetPostDetailsUseCase, GetPostDetailsUseCase>();
}