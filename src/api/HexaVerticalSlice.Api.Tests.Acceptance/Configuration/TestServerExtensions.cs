using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Configuration;

public static class TestServerExtensions
{
    public static bool IsRunningInIntegration(this TestServer testServer) =>
        testServer.Services.GetService<IConfiguration>()!.IsRunningInIntegration();
}