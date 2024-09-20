using FluentAssertions.Extensions;
using HexaVerticalSlice.BC.FeedDisplay.Domain;
using HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Configuration;
using HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Utils;
using NSubstitute;
using Reqnroll;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Steps;

[Binding]
public class ClockSteps(TestClient client, TestApplication application) : StepBase(client, application)
{
    [Given(@"the current date is (.*)")]
    public void GivenTheCurrentDateIs(DateTime now) => GetService<IClock>().Now().Returns(now.AsUtc());
}
