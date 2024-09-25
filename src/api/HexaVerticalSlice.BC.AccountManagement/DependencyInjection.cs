﻿using System.Reflection;
using HexaVerticalSlice.Api.BuildingBlocks.Cqrs;
using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.Api.BuildingBlocks.Time;
using HexaVerticalSlice.BC.AccountManagement.Features.AccountExists;
using HexaVerticalSlice.BC.AccountManagement.Features.Login;
using HexaVerticalSlice.BC.AccountManagement.Features.Register;
using HexaVerticalSlice.BC.AccountManagement.Infra;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HexaVerticalSlice.BC.AccountManagement;

public static class DependencyInjection
{
    private static readonly Assembly CurrentBoundedContextAssembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection RegisterAccountManagementBoundedContext(
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
            .AddTime()
            .AddDomainEventPublishing(CurrentBoundedContextAssembly)
            .AddSharedInfrastructure();

        services
            .AddLoginUseCase()
            .AddRegisterUseCase()
            .AddAccountExistsUseCase();

        return services;
    }
}