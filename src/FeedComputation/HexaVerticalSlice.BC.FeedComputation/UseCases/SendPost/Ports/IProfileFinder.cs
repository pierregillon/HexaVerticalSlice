namespace HexaVerticalSlice.BC.Feeds.UseCases.SendPost.Ports;

public interface IProfileFinder
{
    Task<Guid> GetCurrentProfileId();
}