namespace HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost.Ports;

public interface IProfileFinder
{
    Task<Guid> GetCurrentProfileId();
}