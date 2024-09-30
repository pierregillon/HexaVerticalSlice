using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HexaVerticalSlice.BC.AccountManagement.Infra.Database;

[Table("UserAccount", Schema = "AccountManagement")]
public class UserAccountEntity
{
    [Key] public Guid Id { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
