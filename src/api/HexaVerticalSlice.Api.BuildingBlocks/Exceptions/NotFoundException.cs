namespace HexaVerticalSlice.Api.BuildingBlocks.Exceptions;

public class NotFoundException(string message) : DomainException(message);