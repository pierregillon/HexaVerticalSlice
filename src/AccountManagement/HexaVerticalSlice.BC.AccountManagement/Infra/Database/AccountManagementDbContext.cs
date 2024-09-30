using Microsoft.EntityFrameworkCore;

namespace HexaVerticalSlice.BC.AccountManagement.Infra.Database;

public class AccountManagementDbContext(
    DbContextOptions<AccountManagementDbContext> options,
    IHostEnvironment environment,
    ILogger<AccountManagementDbContext> logger
) : DbContext(options)
{
    public virtual DbSet<UserAccountEntity> Users { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!environment.IsDevelopment())
        {
            optionsBuilder.UseLogging(logger);
        }
    }
}
