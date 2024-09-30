using HexaVerticalSlice.Api.Tests.Acceptance.BCs.AccountManagement.Steps;
using HexaVerticalSlice.Api.Tests.Acceptance.BCs.Networking.Steps;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.Steps;

[Binding]
public class CombinedSteps(UserAccountSteps userAccountSteps, ConnectionSteps connectionSteps)
{
    [Given("I connected the following users")]
    public async Task GivenIConnectedTheFollowingUsers(Table table)
    {
        foreach (var row in table.Rows)
        {
            var emailAddress = row[0];

            await userAccountSteps.WhenIRegisterWithEmail(emailAddress);
            await connectionSteps.WhenIRequestToConnectWith(emailAddress);
            await connectionSteps.WhenTheUserAcceptsMyInvitation(emailAddress);
        }
    }
}