using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;

namespace HexaVerticalSlice.BC.AccountManagement.Domain;

public class BadEmailAddressFormatException() : BadFormatException("The provided email has a bad format.");
