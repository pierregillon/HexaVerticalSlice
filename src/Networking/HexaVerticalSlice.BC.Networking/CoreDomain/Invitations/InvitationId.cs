using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

namespace HexaVerticalSlice.BC.Networking.CoreDomain.Invitations;

public record InvitationId(Guid Value) : IAggregateId
{
    public static InvitationId New() =>
        new(Guid.NewGuid());

    public static InvitationId Rehydrate(Guid id) =>
        new(id);
}