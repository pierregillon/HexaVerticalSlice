using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.CoreDomain;

public record UserAccountRegistered(
    UserAccountId UserAccountId,
    EmailAddress EmailAddress,
    PasswordHash PasswordHash
) : IDomainEvent;