using FluentAssertions;
using HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Utils;
using Reqnroll;
using Reqnroll.Assist;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Steps;

[Binding]
public class ConnectionSteps(TestClient client)
{
    private IReadOnlyCollection<InvitationDto>? _invitations;

    [Given(@"I requested to connect with an unknown user")]
    [When(@"I request to connect with an unknown user")]
    public async Task WhenIRequestToConnectWithAnUnknownUser() =>
        await Invite(Guid.NewGuid());

    [Given(@"I requested to connect with ([^ ]*)")]
    [When(@"I request to connect with ([^ ]*)")]
    public async Task WhenIRequestToConnectWith(string emailAddress)
    {
        var profile = await client.Get<ProfileInfoDto>($"feed-display/v1/profiles/search/{emailAddress}");

        await Invite(profile.Id);
    }

    [Then(@"my invitations list is")]
    public async Task ThenTheInvitationsListIs(Table table)
    {
        _invitations = await client.Get<IReadOnlyCollection<InvitationDto>>("feed-display/v1/invitations");

        var toAssert = _invitations!
            .Select(x => new { InvitedProfile = x.InvitedProfile.EmailAddress, x.RequestDate })
            .ToList();

        var expected = table.ToProjectionOfSet(toAssert).ToList();

        toAssert
            .ToProjection()
            .Should()
            .BeEquivalentTo(expected);
    }

    [When(@"(.*) accepts my invitation")]
    public async Task WhenTheUserUserTestComAcceptsMyInvitation(string emailAddress)
    {
        var profileId = await client.Get<ProfileInfoDto>($"feed-display/v1/profiles/{emailAddress}");
    }

    [Then(@"my connections are")]
    public void ThenMyConnectionsAre(Table table) =>
        ScenarioContext.StepIsPending();

    private async Task Invite(Guid profileId) =>
        await client.PostVoid($"feed-display/v1/profiles/{profileId}/invite", new { });
}

public record ProfileInfoDto(Guid Id);

public record InvitationDto(Guid Id, InvitationDto.ProfileDto InvitedProfile, DateTime RequestDate)
{
    public record ProfileDto(Guid Id, string EmailAddress);
}