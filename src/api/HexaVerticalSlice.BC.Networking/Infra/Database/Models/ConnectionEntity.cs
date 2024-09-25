using System.ComponentModel.DataAnnotations.Schema;

namespace HexaVerticalSlice.BC.Networking.Infra.Database.Models;

[Table("Connection")]
public sealed class ConnectionEntity
{
    public Guid ProfileId { get; set; }
    public Guid ConnectedProfileId { get; set; }
    public DateTime AddedDate { get; set; }
    public ICollection<ProfileEntity>? Profiles { get; set; } = default!;
}