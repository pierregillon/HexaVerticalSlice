using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

namespace HexaVerticalSlice.BC.FeedDisplay.Domain;

public record ProfileId(Guid Value) : IAggregateId
{
    public static ProfileId Rehydrate(Guid id) =>
        new(id);

    public static ProfileId New() =>
        new(Guid.NewGuid());
}