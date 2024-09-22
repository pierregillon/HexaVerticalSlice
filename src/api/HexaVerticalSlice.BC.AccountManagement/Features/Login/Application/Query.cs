using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.AccountManagement.Domain;
using HexaVerticalSlice.BC.AccountManagement.Domain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login.Application;

internal record LogInUserQuery(
    EmailAddress EmailAddress,
    UnverifiedPassword Password
) : IQuery<JwtToken>;
