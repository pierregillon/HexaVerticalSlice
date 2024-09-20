using System.Reflection;
using HexaVerticalSlice.Api.BuildingBlocks;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HexaVerticalSlice.BC.FeedDisplay;

public static class DependencyInjection
{
    private static readonly Assembly CurrentBoundedContextAssembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection RegisterFeedDisplayBoundedContext(
        this IServiceCollection services, 
        Action<MediatRServiceConfiguration>? action = null
    )
    {
        services
            .AddControllers()
            .PartManager
            .ApplicationParts
            .Add(new AssemblyPart(CurrentBoundedContextAssembly));
        
        services
            .AddCqrs(configuration => action?.Invoke(configuration), CurrentBoundedContextAssembly);
        
        // services.AddGetFeed();

        return services;
    }
}