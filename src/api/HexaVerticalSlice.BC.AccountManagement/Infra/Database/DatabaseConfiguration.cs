using System.ComponentModel.DataAnnotations;

namespace HexaVerticalSlice.BC.AccountManagement.Infra.Database;

public class DatabaseConfiguration
{
    public static string Section => "BC:AccountManagement";

    [Required] public string ConnectionString { get; set; } = string.Empty;
}