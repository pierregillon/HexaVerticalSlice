using HexaVerticalSlice.BC.Feeds.Infra.Database.Models;
using HexaVerticalSlice.BC.Feeds.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.Feeds.Infra.Database;

public class FeedComputationDbContext(
    DbContextOptions<FeedComputationDbContext> options
) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("feed_computation");
        modelBuilder.Entity<ConnectionEntity>(x =>
            x.HasKey(y => new { FirstUserAccountId = y.UserId, SecondUserAccountId = y.ConnectedUserId }));
    }

    public DbSet<PostEntity> Posts { get; set; } = default!;
    public DbSet<ConnectionEntity> Connections { get; set; }
}