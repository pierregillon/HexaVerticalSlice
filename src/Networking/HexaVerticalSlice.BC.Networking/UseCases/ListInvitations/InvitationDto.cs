namespace HexaVerticalSlice.BC.Networking.UseCases.ListInvitations;

public record InvitationDto(
    Guid Id,
    InvitationDto.ProfileDto InvitedProfile,
    DateTime RequestDate
)
{
    public record ProfileDto(Guid Id, string EmailAddress);
}