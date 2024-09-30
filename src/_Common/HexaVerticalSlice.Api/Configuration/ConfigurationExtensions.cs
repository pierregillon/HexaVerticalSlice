namespace HexaVerticalSlice.Configuration;

public static class ConfigurationExtensions
{
    public static T Bind<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var config = new T();

        configuration.Bind(sectionName, config);

        return config;
    }
}