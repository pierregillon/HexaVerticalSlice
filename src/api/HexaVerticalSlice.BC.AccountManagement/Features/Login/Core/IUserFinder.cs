using HexaVerticalSlice.BC.AccountManagement.Domain;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login.Core;

internal interface IUserFinder
{
    Task<UserDto?> Find(EmailAddress emailAddress);
}
