using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;

namespace HexaVerticalSlice.BC.AccountManagement.Features.Login.Core;

internal class LoginFailedException(string message) : UnauthorizedException(message);
