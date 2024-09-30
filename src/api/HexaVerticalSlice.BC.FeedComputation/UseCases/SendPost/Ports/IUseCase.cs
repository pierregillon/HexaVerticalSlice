namespace HexaVerticalSlice.BC.Feeds.UseCases.SendPost.Ports;

public interface ISendPostUseCase
{
    Task SendPost(string title, string content);
}