using HexaVerticalSlice.BC.Networking.Contracts;
using HexaVerticalSlice.BC.Networking.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.Networking.Infra.ExternalAdapter;

public class SqlProfileFinder(NetworkingDbContext dbContext) : IProfileFinder
{
    public async Task<Guid> FindFromUserId(Guid userId) =>
        (await dbContext.Profiles.FirstOrDefaultAsync(x => x.UserAccountId == userId))?.Id
        ?? throw new InvalidOperationException("The profile could not be found.");

    public async Task<IReadOnlyCollection<ProfileDetails>> GetDetails(IEnumerable<Guid> profileIds) =>
        await dbContext.Profiles
            .Where(x => profileIds.Contains(x.Id))
            .Select(x => new ProfileDetails(x.Id, x.EmailAddress))
            .ToListAsync();
}