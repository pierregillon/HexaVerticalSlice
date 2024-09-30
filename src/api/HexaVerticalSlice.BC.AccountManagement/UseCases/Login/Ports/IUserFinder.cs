using HexaVerticalSlice.BC.AccountManagement.CoreDomain;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Ports;

internal interface IUserFinder
{
    Task<UserDto?> Find(EmailAddress emailAddress);
}