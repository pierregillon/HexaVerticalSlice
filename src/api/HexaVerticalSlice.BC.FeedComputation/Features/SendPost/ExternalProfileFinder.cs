using HexaVerticalSlice.Api.BuildingBlocks.Tenant;

namespace HexaVerticalSlice.BC.Feeds.Features.SendPost;

public class ExternalProfileFinder(Networking.Contracts.IProfileFinder finder, ICurrentTenant currentTenant)
    : IProfileFinder
{
    public async Task<Guid> GetCurrentProfileId() =>
        await finder.FindFromUserId(currentTenant.GetCurrentUserId().Value);
}