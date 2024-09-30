using System.Reflection;
using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.Feeds.Infra;
using HexaVerticalSlice.BC.Feeds.UseCases;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HexaVerticalSlice.BC.Feeds;

public static class DependencyInjection
{
    private static readonly Assembly CurrentBoundedContextAssembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection RegisterFeedComputationContext(
        this IServiceCollection services,
        Action<MediatRServiceConfiguration> _
    )
    {
        services
            .AddControllers()
            .PartManager
            .ApplicationParts
            .Add(new AssemblyPart(CurrentBoundedContextAssembly));

        services
            .AddDomainEventPublishing(CurrentBoundedContextAssembly)
            .AddSharedInfrastructure()
            .AddUseCases();

        return services;
    }
}