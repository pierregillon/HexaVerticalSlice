namespace HexaVerticalSlice.BC.FeedComputation.UseCases.GetPostDetails.Ports;

public record PostDetailsDto(
    Guid Id,
    string Title,
    string Content,
    IReadOnlyCollection<PostDetailsDto.ThreadDto> Threads
)
{
    public record ThreadDto(Guid ThreadId, CommentDto FirstComment);

    public record CommentDto(string Author, string Comment, DateTime Date);
}