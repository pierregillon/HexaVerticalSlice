using System.Net;
using System.Text.Json;
using FluentAssertions;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.Steps;

[Binding]
public class ErrorSteps(ErrorDriver errorDriver)
{
    [Then(@"an error occurred with message ""(.*)""")]
    public void ThenAnErrorOccuredWithTheMessage(string errorMessage) =>
        ThenAnErrorIsThrownWithCodeAndMessage(message: errorMessage);

    [Then(@"an? (.*) error occurred")]
    public void ThenAnErrorOccured(string statusText) =>
        ThenAnErrorIsThrownWithCodeAndMessage(statusText);

    [Then(@"an? (.*) error occurred with message ""(.*)""")]
    public void ThenAnErrorOccuredWithMessage(string statusText, string message) =>
        ThenAnErrorIsThrownWithCodeAndMessage(statusText, message: message);

    [Then(@"an? (.*) error occurred with type ([^ ]*)")]
    public void ThenAnErrorOccuredWithType(string statusText, string type) =>
        ThenAnErrorIsThrownWithCodeAndMessage(statusText, type);

    [Then(@"an? (.*) error occurred with type ([^ ]*) and message ""(.*)""")]
    public void ThenAnErrorOccuredWithTypeAndMessage(string statusText, string type, string message) =>
        ThenAnErrorIsThrownWithCodeAndMessage(statusText, type, message);

    [Then(@"an? (.*) error occurred with type ([^ ]*) and extension ""(.*)"" to (.*)")]
    public void ThenAnErrorOccuredWithTypeAndExtension(
        string statusText,
        string type,
        string extensionKey,
        string extensionValue
    ) =>
        ThenAnErrorIsThrownWithCodeAndMessage(statusText, type, extensionKey: extensionKey,
            extensionValue: extensionValue);

    private void ThenAnErrorIsThrownWithCodeAndMessage(
        string statusText = "",
        string type = "",
        string message = "",
        string extensionKey = "",
        string extensionValue = ""
    )
    {
        var error = errorDriver.GetLastError();

        if (!string.IsNullOrWhiteSpace(type))
        {
            error.ProblemDetails.Type.Should().Be(type);
        }

        if (!string.IsNullOrWhiteSpace(statusText))
        {
            error.HttpStatusCode
                .Should()
                .Be(HumanizedHelper.ParseEnum<HttpStatusCode>(statusText), $"it should be a {statusText} error.");
        }

        if (!string.IsNullOrWhiteSpace(message))
        {
            error.ProblemDetails.Title.Should().NotBeNull();
            error.ProblemDetails.Title.Should().MatchRegex(message);
        }

        if (!string.IsNullOrWhiteSpace(extensionKey))
        {
            var actualValue = error.ProblemDetails.Extensions[extensionKey];
            actualValue.Should().NotBeNull();
            var jsonElement = (JsonElement)actualValue!;
            jsonElement.GetString().Should().Be(extensionValue);
        }
    }

    [Then(@"no error occurred")]
    public void ThenNoErroroccured() => errorDriver.ThrowIfNotProcessedException();

    [AfterScenario]
    public void ThrowIfNotProcessedException() => errorDriver.ThrowIfNotProcessedException();
}