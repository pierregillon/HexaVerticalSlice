namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;

public record ThreadId(Guid Value)
{
    public static ThreadId Rehydrate(Guid id) =>
        new(id);
}