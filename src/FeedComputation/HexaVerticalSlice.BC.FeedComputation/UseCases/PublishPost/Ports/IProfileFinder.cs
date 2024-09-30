namespace HexaVerticalSlice.BC.Feeds.UseCases.PublishPost.Ports;

public interface IProfileFinder
{
    Task<Guid> GetCurrentProfileId();
}