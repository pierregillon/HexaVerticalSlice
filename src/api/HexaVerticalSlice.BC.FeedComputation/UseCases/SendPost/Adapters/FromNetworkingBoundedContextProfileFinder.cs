using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.Networking.Contracts;

namespace HexaVerticalSlice.BC.Feeds.UseCases.SendPost.Adapters;

public class FromNetworkingBoundedContextProfileFinder(IProfileFinder finder, ICurrentTenant currentTenant)
    : Ports.IProfileFinder
{
    public async Task<Guid> GetCurrentProfileId() =>
        await finder.FindFromUserId(currentTenant.GetCurrentUserId().Value);
}