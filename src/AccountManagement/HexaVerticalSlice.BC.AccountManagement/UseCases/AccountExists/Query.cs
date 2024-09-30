using HexaVerticalSlice.Api.BuildingBlocks.Cqrs.Queries;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.AccountExists;

public record UserAccountExistsQuery(UserAccountId UserAccountId) : IQuery<bool>;