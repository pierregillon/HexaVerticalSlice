namespace HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost.Ports;

public interface IPublishPostUseCase
{
    Task PublishPost(string title, string content);
}