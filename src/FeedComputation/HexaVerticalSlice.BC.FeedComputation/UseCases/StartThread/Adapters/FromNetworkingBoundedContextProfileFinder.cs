using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Ports;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.StartThread.Adapters;

public class FromNetworkingBoundedContextProfileFinder(
    Networking.Contracts.IProfileFinder finder,
    ICurrentTenant currentTenant
)
    : IProfileFinder
{
    public async Task<Guid> GetCurrentProfileId() =>
        await finder.FindFromUserId(currentTenant.GetCurrentUserId().Value);
}