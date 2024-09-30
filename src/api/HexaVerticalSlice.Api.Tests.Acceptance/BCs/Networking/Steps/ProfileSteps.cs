using FluentAssertions;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using HexaVerticalSlice.BC.Networking.UseCases.SearchForProfile;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.Networking.Steps;

[Binding]
public class ProfileSteps(TestClient client)
{
    private ProfileDto? _profileDetails;

    [When(@"I search for (.*) profile")]
    public async Task WhenISearchForProfile(string emailAddress) =>
        _profileDetails = await client.Get<ProfileDto>($"networking/v1/profiles/search/{emailAddress}");

    [Then(@"the profile details are")]
    public void ThenTheProfileDetailsAre(Table table)
    {
        var expectedProfileDetails = table.CreateInstance<ProfileDto>();

        _profileDetails.Should().BeEquivalentTo(expectedProfileDetails, o => o.Excluding(x => x.Id));
    }
}