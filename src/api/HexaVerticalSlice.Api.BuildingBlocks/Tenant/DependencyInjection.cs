using Microsoft.Extensions.DependencyInjection;

namespace HexaVerticalSlice.Api.BuildingBlocks.Tenant;

public static class DependencyInjection
{
    public static IServiceCollection AddTenant(this IServiceCollection services)
    {
        services.AddScoped<ICurrentTenant, InMemoryCurrentTenant>();
        return services;
    }
}