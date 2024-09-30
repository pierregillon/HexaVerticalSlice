using HexaVerticalSlice.Api.Tests.Acceptance.Configuration;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.Steps;

public abstract class StepBase(TestClient client, TestApplication application)
{
    protected readonly TestClient Client = client;

    protected T GetService<T>() => (T)application.Services.GetService(typeof(T))!;
}