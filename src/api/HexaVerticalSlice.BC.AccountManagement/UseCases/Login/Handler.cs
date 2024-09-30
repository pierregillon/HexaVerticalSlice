using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain;
using HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Ports;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login;

internal class LogInUserQueryHandler(
    IUserFinder userFinder,
    IPasswordHashVerifier verifier,
    IJwtTokenGenerator generator
) : IQueryHandler<LogInUserQuery, JwtToken>
{
    public async Task<JwtToken> Handle(LogInUserQuery query)
    {
        var user = await userFinder.Find(query.EmailAddress);

        if (user is null || !verifier.Verify(query.Password, user.PasswordHash))
        {
            throw new LoginFailedException("Incorrect user or password");
        }
            
        return generator.Generate(user.Id, user.EmailAddress);
    }
}
