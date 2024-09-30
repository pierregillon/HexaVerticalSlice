using System.ComponentModel.DataAnnotations;

namespace HexaVerticalSlice.BC.Feeds.Infra.Database;

public class DatabaseConfiguration
{
    public static string Section => "BC:FeedComputation";

    [Required] public string ConnectionString { get; set; } = string.Empty;
}