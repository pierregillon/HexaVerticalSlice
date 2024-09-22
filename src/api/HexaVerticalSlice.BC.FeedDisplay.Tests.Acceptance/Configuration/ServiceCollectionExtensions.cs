using HexaVerticalSlice.BC.AccountManagement.Infra.Database;
using HexaVerticalSlice.BC.FeedDisplay.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace HexaVerticalSlice.BC.FeedDisplay.Tests.Acceptance.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddEntityFrameworkInMemory(this IServiceCollection services)
    {
        var databaseName = Guid.NewGuid().ToString();

        services.RemoveWhere(x => x.ServiceType == typeof(DbContextOptions<FeedDisplayDbContext>));

        services.AddDbContext<FeedDisplayDbContext>(options =>
        {
            options.UseInMemoryDatabase(databaseName);
            options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        });

        services.RemoveWhere(x => x.ServiceType == typeof(DbContextOptions<AccountManagementDbContext>));

        services.AddDbContext<AccountManagementDbContext>(options =>
        {
            options.UseInMemoryDatabase(databaseName);
            options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        });
    }

    private static void RemoveWhere(this IServiceCollection services, Func<ServiceDescriptor, bool> filter)
    {
        var toRemove = services.Where(filter)
            .ToArray();

        foreach (var serviceDescriptor in toRemove)
        {
            services.Remove(serviceDescriptor);
        }
    }
}
