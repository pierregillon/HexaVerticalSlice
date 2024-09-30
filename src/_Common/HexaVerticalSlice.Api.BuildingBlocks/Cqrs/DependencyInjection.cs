using System.Reflection;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Commands;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace HexaVerticalSlice.Api.BuildingBlocks.Cqrs;

public static class DependencyInjection
{
    private static readonly InterfaceTypeCollection CommandAndQueryInterfaceTypesToRegister = new(
    [
        typeof(ICommand),
        typeof(ICommand<>),
        typeof(ICommandHandler<>),
        typeof(ICommandHandler<,>),
        typeof(ICancellableCommandHandler<>),
        typeof(IQuery<>),
        typeof(IQueryHandler<,>)
    ]);

    public static IServiceCollection AddCqrs(
        this IServiceCollection services,
        Action<MediatRServiceConfiguration>? configure = null,
        params Assembly[] commandAndQueryAssemblies
    ) =>
        services
            .AddCommandAndQueryPublishing(commandAndQueryAssemblies, configure)
            .AddTransient<ICommandDispatcher, CommandAndQueryMediatorDispatcher>()
            .AddTransient<IQueryDispatcher, CommandAndQueryMediatorDispatcher>();

    private static IServiceCollection AddCommandAndQueryPublishing(
        this IServiceCollection services,
        Assembly[] commandAndQueryAssemblies,
        Action<MediatRServiceConfiguration>? configure
    )
    {
        if (commandAndQueryAssemblies.Length == 0)
        {
            // auto register nothing, but initialize Mediator
            return services.AddMediatR(configuration =>
            {
                configuration.TypeEvaluator = _ => false;
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configure?.Invoke(configuration);
            });
        }

        return services.AddMediatR(configuration =>
        {
            configuration.TypeEvaluator = CommandAndQueryInterfaceTypesToRegister.IsValid;
            configuration
                .RegisterServicesFromAssemblies(commandAndQueryAssemblies);
            configure?.Invoke(configuration);
        });
    }
}
