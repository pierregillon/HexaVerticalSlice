using System.Reflection;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs;
using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.Feeds.Features;
using HexaVerticalSlice.BC.Feeds.Infra;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HexaVerticalSlice.BC.Feeds;

public static class DependencyInjection
{
    private static readonly Assembly CurrentBoundedContextAssembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection RegisterFeedComputationContext(
        this IServiceCollection services,
        Action<MediatRServiceConfiguration> configureUnitOfWork
    )
    {
        services
            .AddControllers()
            .PartManager
            .ApplicationParts
            .Add(new AssemblyPart(CurrentBoundedContextAssembly));

        services
            .AddCqrs(configureUnitOfWork, CurrentBoundedContextAssembly)
            .AddDomainEventPublishing(CurrentBoundedContextAssembly)
            .AddSharedInfrastructure()
            .AddUseCases();

        return services;
    }
}