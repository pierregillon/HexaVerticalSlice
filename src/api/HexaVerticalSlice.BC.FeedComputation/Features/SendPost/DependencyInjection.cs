namespace HexaVerticalSlice.BC.Feeds.Features.SendPost;

public static class DependencyInjection
{
    public static IServiceCollection AddSendPostUseCase(this IServiceCollection services) =>
        services
            .AddTransient<SendPostUseCase>()
            .AddTransient<IProfileFinder, ExternalProfileFinder>();
}