using HexaVerticalSlice.BC.AccountManagement.Domain;
using HexaVerticalSlice.BC.AccountManagement.Domain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login.Core;

internal record UserDto(
    UserAccountId Id,
    string EmailAddress,
    PasswordHash PasswordHash
);
