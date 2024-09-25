using HexaVerticalSlice.Api.BuildingBlocks.Events;
using HexaVerticalSlice.BC.AccountManagement.Domain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.Domain;

public record UserAccountRegistered(
    UserAccountId UserAccountId,
    EmailAddress EmailAddress,
    PasswordHash PasswordHash
) : IDomainEvent;