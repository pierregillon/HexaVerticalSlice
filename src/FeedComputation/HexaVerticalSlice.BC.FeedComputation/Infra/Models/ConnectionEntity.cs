using System.ComponentModel.DataAnnotations.Schema;

namespace HexaVerticalSlice.BC.Feeds.Infra.Models;

[Table("Connection")]
public class ConnectionEntity
{
    public Guid UserId { get; set; }
    public Guid ProfileId { get; set; }
    public Guid ConnectedUserId { get; set; }
}