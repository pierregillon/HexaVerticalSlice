namespace HexaVerticalSlice.BC.FeedDisplay.Features.ListConnections;

public record ConnectionDto(
    ConnectionDto.ProfileDto ConnectedProfile,
    DateTime AddedDate
)
{
    public record ProfileDto(Guid Id, string EmailAddress);
}