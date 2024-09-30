using System.ComponentModel.DataAnnotations;

namespace HexaVerticalSlice.BC.FeedComputation.Infra.Database;

public class DatabaseConfiguration
{
    public static string Section => "BC:FeedComputation";

    [Required] public string ConnectionString { get; set; } = string.Empty;
}