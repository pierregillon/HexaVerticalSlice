using HexaVerticalSlice.Api.BuildingBlocks.Aggregates;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;

namespace HexaVerticalSlice.BC.Networking.CoreDomain.Profiles;

public interface IProfileRepository : IRepository<Profile, ProfileId>
{
    Task<Profile> Get(UserTenantId id);
}