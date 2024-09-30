using HexaVerticalSlice.BC.AccountManagement.CoreDomain;
using Microsoft.Extensions.Options;

namespace HexaVerticalSlice.BC.AccountManagement.Infra.Database;

public static class DependencyInjection
{
    public static IServiceCollection RegisterDatabaseInfrastructure(this IServiceCollection services)
    {
        services
            .AddOptions<DatabaseConfiguration>()
            .BindConfiguration(DatabaseConfiguration.Section)
            .ValidateDataAnnotations()
            ;
        
        services
            .AddScoped<IUserAccountRepository, SqlUserAccountRepository>()
            .AddDbContext<AccountManagementDbContext>((sp, options) =>
            {
                var configuration = sp.GetRequiredService<IOptions<DatabaseConfiguration>>();

                options.UseNpgsql(configuration);
            })
            ;

        return services;
    }
}
