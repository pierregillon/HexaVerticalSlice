using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Configuration;

public abstract class TestApplicationBase(IReqnrollOutputHelper specFlowOutputHelper)
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder
            .UseContentRoot(AppDomain.CurrentDomain.BaseDirectory)
            .UseEnvironment("test")
            .ConfigureLogging(x =>
            {
                x.AddSimpleConsole(option =>
                {
                    option.IncludeScopes = false;
                    option.TimestampFormat = "hh:mm:ss ";
                });
                x.Services.AddSingleton<ILoggerProvider>(BuildDelegateLoggerProvider);
            })
            .ConfigureServices(ConfigureServices)
            ;
    }

    private DelegateLoggerProvider BuildDelegateLoggerProvider(IServiceProvider serviceProvider)
    {
        var action = new Action<string>(specFlowOutputHelper.WriteLine);
        return ActivatorUtilities.CreateInstance<DelegateLoggerProvider>(serviceProvider, action);
    }

    protected abstract void ConfigureServices(IServiceCollection services);
}