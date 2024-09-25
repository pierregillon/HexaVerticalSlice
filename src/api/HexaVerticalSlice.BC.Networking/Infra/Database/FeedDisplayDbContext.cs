using HexaVerticalSlice.BC.Networking.Infra.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.Networking.Infra.Database;

public class FeedDisplayDbContext(
    DbContextOptions<FeedDisplayDbContext> options
) : DbContext(options)
{
    public DbSet<ProfileEntity> Profiles { get; set; } = default!;
    public DbSet<InvitationEntity> Invitations { get; set; } = default!;
    public DbSet<ConnectionEntity> Connections { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("feed_display");

        modelBuilder.Entity<ConnectionEntity>(x => x.HasKey(y => new { y.ProfileId, y.ConnectedProfileId }));
        modelBuilder.Entity<ProfileEntity>(x => x.HasMany(y => y.Connections).WithMany(z => z.Profiles));
    }
}