using Reqnroll;
using Reqnroll.UnitTestProvider;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Configuration;

[Binding]
public sealed class ScenarioInitializer(
    ScenarioContext scenarioContext,
    ScenarioInfo scenarioInfo,
    TestApplication application
)
    : IDisposable
{
    [BeforeScenario]
    public void InitializeAsync()
    {
        if (application.Server.IsRunningInIntegration() && CurrentScenarioIsAcceptanceTest())
        {
            IgnoreScenario();
        }
        else
        {
            var httpClient = application.Server.CreateClient();
            scenarioContext.Set(httpClient);
        }
    }

    private bool CurrentScenarioIsAcceptanceTest() => !scenarioInfo.Tags.Contains("Integration");

    private void IgnoreScenario()
    {
        var runtimeProvider =
            (IUnitTestRuntimeProvider)scenarioContext.GetBindingInstance(typeof(IUnitTestRuntimeProvider));

        runtimeProvider.TestIgnore(
            "Cannot execute the current scenario: it has not been configured as integration test."
        );
    }

    public void Dispose() => application.Dispose();
}