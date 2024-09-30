using FluentAssertions.Extensions;
using HexaVerticalSlice.Api.BuildingBlocks.Time;
using HexaVerticalSlice.Api.Tests.Acceptance.Configuration;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using NSubstitute;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.Steps;

[Binding]
public class ClockSteps(TestClient client, TestApplication application) : StepBase(client, application)
{
    [Given(@"the current date is (.*)")]
    public void GivenTheCurrentDateIs(DateTime now) => GetService<IClock>().Now().Returns(now.AsUtc());
}