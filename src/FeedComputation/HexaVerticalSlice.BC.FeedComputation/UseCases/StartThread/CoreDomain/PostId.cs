namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.CoreDomain;

public record PostId(Guid Value)
{
    public static PostId Rehydrate(Guid id) =>
        new(id);
}