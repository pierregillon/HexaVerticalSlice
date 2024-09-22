using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;

namespace HexaVerticalSlice.BC.AccountManagement.Domain;

public record UserAccountId(Guid Value) : IAggregateId
{
    public static UserAccountId New() => new(Guid.NewGuid());
    public static UserAccountId Rehydrate(Guid value) => new(value);

    public static implicit operator Guid(UserAccountId userAccountId) => userAccountId.Value;
}
