using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.AccountManagement.Domain;

namespace HexaVerticalSlice.BC.AccountManagement.Features.AccountExists;

public record UserAccountExistsQuery(UserAccountId UserAccountId) : IQuery<bool>
{
}