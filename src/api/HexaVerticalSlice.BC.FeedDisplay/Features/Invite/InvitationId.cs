using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

namespace HexaVerticalSlice.BC.FeedDisplay.Features.Invite;

public record InvitationId(Guid Value) : IAggregateId
{
    public static InvitationId New() =>
        new(Guid.NewGuid());
}