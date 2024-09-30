namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;

public interface IProfileFinder
{
    Task<Guid> GetCurrentProfileId();
}