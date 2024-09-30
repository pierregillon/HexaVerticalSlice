using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;

namespace HexaVerticalSlice.BC.AccountManagement.CoreDomain;

public class BadEmailAddressFormatException() : BadFormatException("The provided email has a bad format.");
