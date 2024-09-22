using Microsoft.Extensions.DependencyInjection;

namespace HexaVerticalSlice.Api.BuildingBlocks.Time;

public static class DependencyInjection
{
    public static IServiceCollection AddTime(this IServiceCollection services)
    {
        services.AddTransient<IClock, SystemClock>();
        return services;
    }
}