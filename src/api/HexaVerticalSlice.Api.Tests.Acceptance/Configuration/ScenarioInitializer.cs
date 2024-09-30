using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Configuration;

[Binding]
public sealed class ScenarioInitializer(
    ScenarioContext scenarioContext,
    TestApplication application
) : IDisposable
{
    [BeforeScenario]
    public void InitializeAsync()
    {
        scenarioContext.Set(application.Server.CreateClient());
    }

    public void Dispose() => application.Dispose();
}