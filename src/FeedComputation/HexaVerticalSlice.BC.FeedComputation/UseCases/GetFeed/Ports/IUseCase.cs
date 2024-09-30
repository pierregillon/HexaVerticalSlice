namespace HexaVerticalSlice.BC.FeedComputation.UseCases.GetFeed.Ports;

public interface IGetFeedUseCase
{
    Task<FeedDto> Execute();
}