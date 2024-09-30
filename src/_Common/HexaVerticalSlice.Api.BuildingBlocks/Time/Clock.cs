namespace HexaVerticalSlice.Api.BuildingBlocks.Time;

public class SystemClock : IClock
{
    public DateTime Now() => DateTime.UtcNow;
}