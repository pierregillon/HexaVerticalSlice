using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.Feeds.UseCases.SendPost.Ports;

namespace HexaVerticalSlice.BC.Feeds.UseCases.SendPost.Adapters;

public class ExternalProfileFinder(Networking.Contracts.IProfileFinder finder, ICurrentTenant currentTenant)
    : IProfileFinder
{
    public async Task<Guid> GetCurrentProfileId() =>
        await finder.FindFromUserId(currentTenant.GetCurrentUserId().Value);
}