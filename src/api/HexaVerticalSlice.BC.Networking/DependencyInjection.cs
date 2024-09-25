using System.Reflection;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs;
using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.Networking.Infra;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HexaVerticalSlice.BC.Networking;

public static class DependencyInjection
{
    private static readonly Assembly CurrentBoundedContextAssembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection RegisterNetworkingBoundedContext(
        this IServiceCollection services,
        Action<MediatRServiceConfiguration> action
    )
    {
        services
            .AddControllers()
            .PartManager
            .ApplicationParts
            .Add(new AssemblyPart(CurrentBoundedContextAssembly));

        services
            .AddCqrs(action, CurrentBoundedContextAssembly)
            .AddDomainEventPublishing(CurrentBoundedContextAssembly);

        services.AddSharedInfrastructure();

        return services;
    }
}