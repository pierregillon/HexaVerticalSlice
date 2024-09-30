using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login;

internal class LoginFailedException(string message) : UnauthorizedException(message);