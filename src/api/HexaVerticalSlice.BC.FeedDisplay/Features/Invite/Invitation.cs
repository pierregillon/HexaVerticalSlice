using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.BC.FeedDisplay.Features.SearchForProfile;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

public class Invitation : AggregateRoot<InvitationId>
{
    public InvitationId Id { get; }
    public ProfileId SenderId { get; }
    public ProfileId TargetId { get; }
    public DateTime RequestDate { get; }

    public static Invitation Create(ProfileId senderId, ProfileId targetId, DateTime requestDate) =>
        new(InvitationId.New(), senderId, targetId, requestDate);

    private Invitation(InvitationId id, ProfileId senderId, ProfileId targetId, DateTime requestDate) : base(id)
    {
        Id = id;
        SenderId = senderId;
        TargetId = targetId;
        RequestDate = requestDate;
    }
}