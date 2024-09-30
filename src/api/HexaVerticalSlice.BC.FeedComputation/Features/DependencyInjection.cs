using HexaVerticalSlice.BC.Feeds.Features.SendPost;

namespace HexaVerticalSlice.BC.Feeds.Features;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services
            .AddSendPostUseCase()
            ;

        return services;
    }
}