using System.ComponentModel.DataAnnotations;

namespace HexaVerticalSlice.BC.Networking.Infra.Database;

public class DatabaseConfiguration
{
    public static string Section => "BC:Networking";

    [Required] public string ConnectionString { get; set; } = string.Empty;
}