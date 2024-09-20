using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Configuration;

public static class TestServerExtensions
{
    public static bool IsRunningInIntegration(this TestServer testServer)
    {
        return testServer.Services.GetService<IConfiguration>()!.IsRunningInIntegration();
    }
}
