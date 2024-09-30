using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;

namespace HexaVerticalSlice.BC.AccountManagement.UseCases.Login.Ports;

internal class LoginFailedException(string message) : UnauthorizedException(message);
