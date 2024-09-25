using System.Reflection;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs;
using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.FeedDisplay.Infra;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HexaVerticalSlice.BC.FeedDisplay;

public static class DependencyInjection
{
    private static readonly Assembly CurrentBoundedContextAssembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection RegisterFeedDisplay(
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
            .AddCqrs(configuration => action?.Invoke(configuration), CurrentBoundedContextAssembly)
            .AddDomainEventPublishing(CurrentBoundedContextAssembly);

        services.AddSharedInfrastructure();

        return services;
    }
}