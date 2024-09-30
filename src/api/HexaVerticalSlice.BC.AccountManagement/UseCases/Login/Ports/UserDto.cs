using HexaVerticalSlice.BC.AccountManagement.CoreDomain;
using HexaVerticalSlice.BC.AccountManagement.CoreDomain.Security;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Ports;

internal record UserDto(
    UserAccountId Id,
    string EmailAddress,
    PasswordHash PasswordHash
);
