using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;

namespace HexaVerticalSlice.BC.AccountManagement.Domain.Security;

public class TooWeakPasswordException() : BadFormatException("The provided password is too weak.");
