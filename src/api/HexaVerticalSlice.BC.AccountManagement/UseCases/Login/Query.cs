using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login;

internal record LogInUserQuery(
    EmailAddress EmailAddress,
    UnverifiedPassword Password
) : IQuery<JwtToken>;
