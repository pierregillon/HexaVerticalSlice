using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.BC.FeedDisplay.Domain;
using HexaVerticalSlice.BC.FeedDisplay.Features.SearchForProfile;

namespace HexaVerticalSlice.BC.FeedDisplay.Infra;

public class SqlProfileRepository(FeedDisplayDbContext dbContext) : IProfileRepository
{
    public Task<Profile> Get(ProfileId id)
    {
        var entity = dbContext.Profiles.Find(id.Value);

        return entity is null
            ? throw new NotFoundException($"The profile with id '{id.Value}' could not be found.")
            : Task.FromResult(Rehydrate(entity));
    }

    public Task<Profile> Get(UserTenantId id)
    {
        var entity = dbContext.Profiles.FirstOrDefault(x => x.UserAccountId == id.Value);

        return entity is null
            ? throw new NotFoundException($"The profile with id '{id.Value}' could not be found.")
            : Task.FromResult(Rehydrate(entity));
    }

    public async Task Save(Profile profile)
    {
        var profileEntity = new ProfileEntity
        {
            Id = profile.Id.Value,
            EmailAddress = profile.EmailAddress,
            UserAccountId = profile.UserAccountId
        };
        await dbContext.Profiles.AddAsync(profileEntity);
    }

    private static Profile Rehydrate(ProfileEntity entity) =>
        Profile.Rehydrate(
            new ProfileId(entity.Id),
            entity.EmailAddress,
            entity.UserAccountId
        );
}