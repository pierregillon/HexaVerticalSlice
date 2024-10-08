using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HexaVerticalSlice.BC.Networking.Infra.Database.Models;

[Table("Profile")]
public class ProfileEntity
{
    [Key] public Guid Id { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
    public Guid UserAccountId { get; set; }

    public virtual ICollection<ConnectionEntity> Connections { get; set; } = default!;
}