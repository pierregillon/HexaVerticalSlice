namespace HexaVerticalSlice.BC.Feeds.UseCases.GetFeed.Ports;

public interface IGetFeedUseCase
{
    Task<FeedDto> Execute();
}