using HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Configuration;
using HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Utils;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Steps;

public abstract class StepBase(TestClient client, TestApplication application)
{
    protected readonly TestClient Client = client;

    protected T GetService<T>() => (T)application.Services.GetService(typeof(T))!;

}
