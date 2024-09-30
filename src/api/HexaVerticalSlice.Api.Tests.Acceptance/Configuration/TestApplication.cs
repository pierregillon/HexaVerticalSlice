using HexaVerticalSlice.Api.BuildingBlocks.Time;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Configuration;

public class TestApplication(IReqnrollOutputHelper specFlowOutputHelper)
    : TestApplicationBase(specFlowOutputHelper)
{
    protected override void OverrideAcceptanceServices(IServiceCollection services)
    {
        services.AddEntityFrameworkInMemory();
        services.AddSingleton(_ =>
        {
            var clock = Substitute.For<IClock>();
            clock.Now().Returns(_ => DateTime.UtcNow);
            return clock;
        });
    }

    protected override void OverrideAcceptanceTestServices(IServiceCollection services)
    {
    }

    protected override void OverrideIntegrationServices(IServiceCollection services)
    {
    }

    protected override void OverrideIntegrationTestServices(IServiceCollection services)
    {
    }
}