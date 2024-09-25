using FluentAssertions;
using HexaVerticalSlice.Api.Tests.Acceptance.BCs.AccountManagement.Steps;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using HexaVerticalSlice.BC.AccountManagement.Domain;
using Reqnroll;
using Reqnroll.Assist;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.Networking.Steps;

[Binding]
public class ConnectionSteps(TestClient client)
{
    private IReadOnlyCollection<InvitationDto>? _invitations;
    private Guid? _invitationId;

    [Given(@"I invited ([^ ]*) to connect with")]
    [When(@"I invite ([^ ]*) to connect with")]
    public async Task WhenIRequestToConnectWith(string emailAddress)
    {
        var profile = await GetProfile(emailAddress);

        _invitationId = await Invite(profile.Id);
    }

    [Then(@"my invitations list is")]
    public async Task ThenTheInvitationsListIs(Table table)
    {
        _invitations = await ListInvitations();

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
        if (_invitationId.HasValue == false)
        {
            throw new InvalidOperationException("No invitation id has been defined.");
        }

        var currentToken = client.CurrentToken;
        var currentEmailAddress = client.CurrentEmailAddress;

        var token = await client.Post<JwtToken>(
            "account-management/v1/users/login",
            new { email = emailAddress, password = UserAccountSteps.DefaultPassword }
        );

        client.DefineToken(emailAddress, token.Token);

        await client.PostVoid($"networking/v1/invitations/{_invitationId.Value}/accept", new { });

        client.DefineToken(currentEmailAddress!, currentToken!);
    }

    [Then(@"my connections are")]
    public async Task ThenMyConnectionsAre(Table table)
    {
        var profile = await GetProfile(client.CurrentEmailAddress!);
        var connections = await ListConnections(profile.Id);

        connections
            .Should()
            .HaveCount(table.RowCount);
    }

    [Then(@"(.*)'s connections are")]
    public async Task ThenMyConnectionsAre(string emailAddress, Table table)
    {
        var profile = await GetProfile(emailAddress);
        var connections = await ListConnections(profile.Id);

        var query = connections
            .Select(x => new { User = x.ConnectedProfile.EmailAddress, x.AddedDate })
            .ToList();

        var expected = table.ToProjectionOfSet(query).ToList();

        query
            .ToProjection()
            .Should()
            .BeEquivalentTo(expected);
    }

    private async Task<IEnumerable<ConnectionDto>> ListConnections(Guid profileId) =>
        await client.Get<IReadOnlyCollection<ConnectionDto>>($"networking/v1/profile/{profileId}/connections");

    private async Task<Guid> Invite(Guid profileId) =>
        await client.Post<Guid>($"networking/v1/profiles/{profileId}/invite", new { });

    private async Task<ProfileInfoDto> GetProfile(string emailAddress) =>
        await client.Get<ProfileInfoDto>($"networking/v1/profiles/search/{emailAddress}");

    private async Task<IReadOnlyCollection<InvitationDto>> ListInvitations() =>
        await client.Get<IReadOnlyCollection<InvitationDto>>("networking/v1/invitations");
}

public record ProfileInfoDto(Guid Id);

public record InvitationDto(Guid Id, InvitationDto.ProfileDto InvitedProfile, DateTime RequestDate)
{
    public record ProfileDto(Guid Id, string EmailAddress);
}

public record ConnectionDto(Guid Id, InvitationDto.ProfileDto ConnectedProfile, DateTime AddedDate)
{
    public record ProfileDto(Guid Id, string EmailAddress);
}