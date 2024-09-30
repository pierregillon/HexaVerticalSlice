using HexaVerticalSlice.BC.AccountManagement.Infra.Database;
using HexaVerticalSlice.BC.Feeds.Infra.Database;
using HexaVerticalSlice.BC.Networking.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Configuration;

public static class ServiceCollectionExtensions
{
    public static void AddEntityFrameworkInMemory(this IServiceCollection services)
    {
        var databaseName = Guid.NewGuid().ToString();

        ConfigureInMemoryDb<AccountManagementDbContext>(services, databaseName);
        ConfigureInMemoryDb<NetworkingDbContext>(services, databaseName);
        ConfigureInMemoryDb<FeedComputationDbContext>(services, databaseName);
    }

    private static IServiceCollection ConfigureInMemoryDb<T>(this IServiceCollection services, string databaseName)
        where T : DbContext
    {
        services.RemoveWhere(x => x.ServiceType == typeof(DbContextOptions<T>));

        services.AddDbContext<T>(options =>
        {
            options.UseInMemoryDatabase(databaseName);
            options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        });

        return services;
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