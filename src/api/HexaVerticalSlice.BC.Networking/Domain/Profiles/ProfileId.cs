using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

namespace HexaVerticalSlice.BC.Networking.Domain.Profiles;

public record ProfileId(Guid Value) : IAggregateId
{
    public static ProfileId Rehydrate(Guid id) =>
        new(id);

    public static ProfileId New() =>
        new(Guid.NewGuid());
}