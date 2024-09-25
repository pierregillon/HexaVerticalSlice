using FluentAssertions;
using HexaVerticalSlice.BC.FeedDisplay.Features.SearchForProfile;
using HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Utils;
using Reqnroll;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Steps;

[Binding]
public class ProfileSteps(TestClient client)
{
    private ProfileDto? _profileDetails;

    [When(@"I search for (.*) profile")]
    public async Task WhenISearchForProfile(string emailAddress) =>
        _profileDetails = await client.Get<ProfileDto>($"feed-display/v1/profiles/search/{emailAddress}");

    [Then(@"the profile details are")]
    public void ThenTheProfileDetailsAre(Table table)
    {
        var expectedProfileDetails = table.CreateInstance<ProfileDto>();

        _profileDetails.Should().BeEquivalentTo(expectedProfileDetails, o => o.Excluding(x => x.Id));
    }
}