using System.Reflection;
using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.FeedComputation.Infra;
using HexaVerticalSlice.BC.FeedComputation.UseCases;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HexaVerticalSlice.BC.FeedComputation;

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