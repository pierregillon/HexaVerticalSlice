using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.FeedDisplay.Infra;

public class FeedDisplayDbContext(
    DbContextOptions<FeedDisplayDbContext> options
) : DbContext(options)
{
    public DbSet<ProfileEntity> Profiles { get; set; } = default!;
    public DbSet<InvitationEntity> Invitations { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("feed_display");
    }
}