using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace HexaVerticalSlice.BC.FeedComputation.Infra.Database;

internal static class DbContextExtensions
{
    internal static DbContextOptionsBuilder UseNpgsql(
        this DbContextOptionsBuilder options,
        IOptions<DatabaseConfiguration> dbConfiguration
    ) =>
        options.UseNpgsql(
            dbConfiguration.Value.ConnectionString,
            sqlOptions => { sqlOptions.CommandTimeout(60 * 60); }
        );

    internal static DbContextOptionsBuilder UseLogging(
        this DbContextOptionsBuilder options,
        ILogger<FeedComputationDbContext> logger
    ) =>
        options
            .LogTo((_1, _2) => true, e => logger.Log(e.LogLevel, e.EventId, e.ToString()))
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.ContextInitialized));
}