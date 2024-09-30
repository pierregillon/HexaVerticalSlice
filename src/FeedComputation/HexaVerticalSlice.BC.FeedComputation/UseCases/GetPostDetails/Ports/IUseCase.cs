namespace HexaVerticalSlice.BC.FeedComputation.UseCases.GetPostDetails.Ports;

public interface IGetPostDetailsUseCase
{
    public Task<PostDetailsDto> GetDetails(Guid postId);
}