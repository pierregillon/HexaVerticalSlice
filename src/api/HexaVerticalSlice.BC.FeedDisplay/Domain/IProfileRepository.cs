using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.FeedDisplay.Features.SearchForProfile;

namespace HexaVerticalSlice.BC.FeedDisplay.Domain;

public interface IProfileRepository : IRepository<Profile, ProfileId>
{
    Task<Profile> Get(UserTenantId id);
}