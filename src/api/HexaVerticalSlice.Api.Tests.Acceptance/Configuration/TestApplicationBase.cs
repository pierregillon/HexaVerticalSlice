using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Configuration;

public abstract class TestApplicationBase(IReqnrollOutputHelper specFlowOutputHelper)
    : WebApplicationFactory<Program>
{
    private IConfiguration? _configuration;

    private IConfiguration Configuration => _configuration ?? throw new ArgumentNullException(nameof(Configuration));

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureAppConfiguration((_, conf) => _configuration = conf.Build());

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
            .ConfigureTestServices(ConfigureTestServices)
            ;
    }

    private DelegateLoggerProvider BuildDelegateLoggerProvider(IServiceProvider serviceProvider)
    {
        var action = new Action<string>(specFlowOutputHelper.WriteLine);
        return ActivatorUtilities.CreateInstance<DelegateLoggerProvider>(serviceProvider, action);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        if (Configuration.IsRunningInAcceptance())
        {
            OverrideAcceptanceServices(services);
        }

        if (Configuration.IsRunningInIntegration())
        {
            OverrideIntegrationServices(services);
        }
    }

    private void ConfigureTestServices(IServiceCollection services)
    {
        if (Configuration.IsRunningInAcceptance())
        {
            OverrideAcceptanceTestServices(services);
        }

        if (Configuration.IsRunningInIntegration())
        {
            OverrideIntegrationTestServices(services);
        }
    }

    protected abstract void OverrideAcceptanceServices(IServiceCollection services);
    protected abstract void OverrideAcceptanceTestServices(IServiceCollection services);
    protected abstract void OverrideIntegrationServices(IServiceCollection services);
    protected abstract void OverrideIntegrationTestServices(IServiceCollection services);
}