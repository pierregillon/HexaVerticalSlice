using Microsoft.Extensions.Configuration;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Configuration;

public static class ConfigurationExtensions
{
    private const string TestFlavorKey = "TestFlavor";

    public static bool IsRunningInIntegration(this IConfiguration configuration) => configuration.GetSection(TestFlavorKey).Value == "integration";
    public static bool IsRunningInAcceptance(this IConfiguration configuration) => !configuration.IsRunningInIntegration();

}
