using HexaVerticalSlice.Api.BuildingBlocks.Exceptions;
using HexaVerticalSlice.Api.BuildingBlocks.Tenant;
using HexaVerticalSlice.Api.BuildingBlocks.Time;
using HexaVerticalSlice.BC.FeedDisplay.Domain;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.FeedDisplay.Infra;

public class SqlProfileRepository(FeedDisplayDbContext dbContext, IClock clock) : IProfileRepository
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
        var entity = await dbContext.Profiles
            .Include(x => x.Connections)
            .FirstOrDefaultAsync(x => x.Id == profile.Id.Value);

        if (entity is null)
        {
            entity = new ProfileEntity
            {
                Id = profile.Id.Value,
                EmailAddress = profile.EmailAddress,
                UserAccountId = profile.UserAccountId
            };

            foreach (var connectedProfileId in profile.Connections)
            {
                entity.Connections.Add(new ConnectionEntity
                {
                    ProfileId = profile.Id.Value,
                    ConnectedProfileId = connectedProfileId.Value,
                    AddedDate = clock.Now()
                });
            }

            await dbContext.Profiles.AddAsync(entity);
        }
        else
        {
            entity.EmailAddress = profile.EmailAddress;
            entity.UserAccountId = profile.UserAccountId;

            entity.Connections.Clear();

            foreach (var connectedProfileId in profile.Connections)
            {
                entity.Connections.Add(new ConnectionEntity
                {
                    ProfileId = profile.Id.Value,
                    ConnectedProfileId = connectedProfileId.Value,
                    AddedDate = clock.Now()
                });
            }
        }
    }

    private static Profile Rehydrate(ProfileEntity entity) =>
        Profile.Rehydrate(
            new ProfileId(entity.Id),
            entity.EmailAddress,
            entity.UserAccountId
        );
}