using HexaVerticalSlice.BC.FeedComputation.Infra.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.FeedComputation.Infra.Database;

public class FeedComputationDbContext(
    DbContextOptions<FeedComputationDbContext> options
) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("feed_computation");

        modelBuilder.Entity<ConnectionEntity>(x =>
            x.HasKey(y => new { FirstUserAccountId = y.UserId, SecondUserAccountId = y.ConnectedUserId })
        );

        modelBuilder.Entity<PostEntity>(x =>
            x.HasMany(y => y.Threads)
                .WithOne(z => z.Post)
                .HasForeignKey(z => z.PostId)
        );

        modelBuilder.Entity<ThreadEntity>(x =>
            x.HasMany(y => y.Comments)
                .WithOne(z => z.Thread)
                .HasForeignKey(z => z.ThreadId)
        );
    }

    public DbSet<PostEntity> Posts { get; set; } = default!;
    public DbSet<ConnectionEntity> Connections { get; set; } = default!;
    public DbSet<ThreadEntity> Threads { get; set; } = default!;
}