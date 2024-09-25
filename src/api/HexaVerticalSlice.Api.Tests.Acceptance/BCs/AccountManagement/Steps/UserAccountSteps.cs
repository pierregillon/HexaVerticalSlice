using FluentAssertions;
using FluentAssertions.Extensions;
using HexaVerticalSlice.Api.Tests.Acceptance.BCs.Steps;
using HexaVerticalSlice.Api.Tests.Acceptance.Configuration;
using HexaVerticalSlice.Api.Tests.Acceptance.Utils;
using HexaVerticalSlice.BC.AccountManagement.Domain;
using HexaVerticalSlice.BC.AccountManagement.Infra.TokenGeneration;
using Microsoft.Extensions.Options;
using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.BCs.AccountManagement.Steps;

[Binding]
public class UserAccountSteps(TestClient client, TestApplication application) : StepBase(client, application)
{
    public const string DefaultPassword = "test";
    private JwtToken? _token;

    [Given(@"I am registered and log in")]
    public async Task GivenIAmRegisteredAndLogIn()
    {
        var email = $"{Guid.NewGuid()}@test.com";

        var token = await Register(email, DefaultPassword);

        Client.DefineToken(email, token.Token);
    }

    [Given(@"(.*) has registered")]
    [When(@"I register with email ""(.*)""")]
    public async Task WhenIRegisterWithEmail(string emailAddress) => await Register(emailAddress, DefaultPassword);

    [When(@"I register with password ""(.*)""")]
    public async Task WhenIRegisterWithPassword(string password) => await Register("test@test.fr", password);

    [Given(@"I am registered and logged in as (.*)")]
    public async Task GivenIAmRegisteredAndLoggedInAs(string emailAddress)
    {
        var token = await Register(emailAddress, DefaultPassword);

        Client.DefineToken(emailAddress, token.Token);
    }

    [Given(@"I am registered and logged in with")]
    [When(@"I register and log in with")]
    public async Task WhenIRegisterAndLogInWith(Table table)
    {
        var (data, token) = await RegisterFromTable(table);

        if (token is not null)
        {
            Client.DefineToken(data.EmailAddress, token.Token);
        }

        _token = token;
    }

    [Given(@"I am registered with")]
    public Task WhenIRegisterWith(Table table) => RegisterFromTable(table);

    [When("I log in with")]
    public async Task WhenILogInWith(Table table)
    {
        var data = table.CreateInstance<UserInfo>();

        var token = await LogIn(data.EmailAddress, data.Password);

        if (token is not null)
        {
            Client.DefineToken(data.EmailAddress, token.Token);

            _token = token;
        }
    }

    [Given(@"the token validity is (.*) days")]
    public void GivenTheTokenValidityIsDays(int dayCount)
    {
        var options = GetService<IOptions<JwtBearerTokenOptions>>();

        options.Value.Validity = TimeSpan.FromDays(dayCount);
    }

    [Then(@"I can now use the app until the (.*)")]
    public void ThenICanNowUserTheAppUntilThe(DateTime date)
    {
        _token.Should().NotBeNull();
        _token!.Token.Should().NotBeNull();
        _token!.ExpireAt.Should().Be(date.AsUtc());
    }

    private async Task<(UserInfo Data, JwtToken? Token)> RegisterFromTable(Table table)
    {
        var data = table.CreateInstance<UserInfo>();

        var token = await Register(data.EmailAddress, data.Password);

        return (data, token);
    }

    private async Task<JwtToken> Register(string email, string password)
        => await Client.Post<JwtToken>("account-management/v1/users/register", new { email, password });

    private async Task<JwtToken?> LogIn(string email, string password)
        => await Client.Post<JwtToken>("account-management/v1/users/login", new { email, password });

    public record UserInfo(string EmailAddress, string Password);
}