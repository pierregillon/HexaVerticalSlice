namespace HexaVerticalSlice.BC.Feeds.UseCases.PublishPost.Ports;

public interface IPublishPostUseCase
{
    Task PublishPost(string title, string content);
}