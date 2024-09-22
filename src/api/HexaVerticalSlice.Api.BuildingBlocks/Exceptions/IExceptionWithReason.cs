namespace HexaVerticalSlice.Api.BuildingBlocks.Exceptions;

public interface IExceptionWithReason
{
    string Reason { get; }
}