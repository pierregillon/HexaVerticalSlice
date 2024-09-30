namespace HexaVerticalSlice.BC.Feeds.Features.SendPost;

public interface IProfileFinder
{
    Task<Guid> GetCurrentProfileId();
}