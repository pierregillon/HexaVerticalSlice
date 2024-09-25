using System.ComponentModel.DataAnnotations;

namespace HexaVerticalSlice.BC.FeedDisplay.Infra;

public class DatabaseConfiguration
{
    public static string Section => "BC:FeedDisplay";

    [Required] public string ConnectionString { get; set; } = string.Empty;
}