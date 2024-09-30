using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.Networking.Contracts;

namespace HexaVerticalSlice.BC.FeedComputation.UseCases.PublishPost.Adapters;

public class FromNetworkingBoundedContextProfileFinder(IProfileFinder finder, ICurrentTenant currentTenant)
    : Ports.IProfileFinder
{
    public async Task<Guid> GetCurrentProfileId() =>
        await finder.FindFromUserId(currentTenant.GetCurrentUserId().Value);
}