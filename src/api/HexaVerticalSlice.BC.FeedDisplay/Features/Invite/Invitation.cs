using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.BC.FeedDisplay.Domain;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

public class Invitation : AggregateRoot<InvitationId>
{
    public InvitationId Id { get; }
    public ProfileId SenderId { get; }
    public ProfileId TargetId { get; }
    public DateTime RequestDate { get; }
    public bool IsAccepted { get; set; }

    public static Invitation Create(ProfileId senderId, ProfileId targetId, DateTime requestDate) =>
        new(InvitationId.New(), senderId, targetId, requestDate);

    public static Invitation Rehydrate(
        InvitationId invitationId,
        ProfileId sender,
        ProfileId target,
        DateTime requestDate
    ) =>
        new(invitationId, sender, target, requestDate);

    private Invitation(InvitationId id, ProfileId senderId, ProfileId targetId, DateTime requestDate) : base(id)
    {
        Id = id;
        SenderId = senderId;
        TargetId = targetId;
        RequestDate = requestDate;
    }

    public void Accept()
    {
        IsAccepted = true;
        ApplyEvent(new InvitationAccepted(Id, SenderId, TargetId));
    }
}