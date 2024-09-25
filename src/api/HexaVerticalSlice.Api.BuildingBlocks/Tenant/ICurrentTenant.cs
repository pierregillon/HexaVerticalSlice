namespace HexaVerticalSlice.Api.BuildingBlocks.Tenant;

public interface ICurrentTenant
{
    UserTenantId? UserTenantId { get; }
    void DefineUserId(UserTenantId userTenantId);

    public UserTenantId GetCurrentUserId() =>
        UserTenantId ?? throw new InvalidOperationException("No user tenant id defined.");
}