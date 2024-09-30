using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;

namespace HexaVerticalSlice.Configuration.Controllers;

public static class DependencyInjection
{
    public static IServiceCollection AddControllerServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddControllers(_ => { })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
            });

        services.AddHttpLogging(_ => { });

        services.AddScoped<ValidateUserExistenceMiddleware>();
        services.AddScoped<InitializeUserContextMiddleware>();

        services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
        });

        return services;
    }

    public static WebApplication ConfigureControllers(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseResponseCompression();
        }

        app.UseHttpLogging();

        app
            .UseAuthentication()
            .UseMiddleware<InitializeUserContextMiddleware>()
            .UseMiddleware<ValidateUserExistenceMiddleware>()
            ;

        app.MapControllers();
        app.UseAuthorization();
        app.UseExceptionHandler("/internal/error");

        return app;
    }
}