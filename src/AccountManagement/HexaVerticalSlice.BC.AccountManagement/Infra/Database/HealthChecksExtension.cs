using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HexaVerticalSlice.BC.AccountManagement.Infra.Database;

public static class HealthChecksExtension
{
    public static IHealthChecksBuilder AddAccountManagementDatabaseCheck(this IHealthChecksBuilder builder) =>
        builder.AddDbContextCheck<AccountManagementDbContext>(
            $"{nameof(AccountManagementDbContext)} readiness check",
            HealthStatus.Unhealthy,
            new[] { "persistence", "database", "readiness" }
        );
}
