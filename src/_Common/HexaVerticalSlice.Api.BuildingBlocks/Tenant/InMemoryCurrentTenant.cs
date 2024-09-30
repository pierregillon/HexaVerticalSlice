namespace HexaVerticalSlice.Api.BuildingBlocks.Tenant;

public record InMemoryCurrentTenant : ICurrentTenant
{
    public UserTenantId? UserTenantId { get; private set; }
    public void DefineUserId(UserTenantId userTenantId) => UserTenantId = userTenantId;
}