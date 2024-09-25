using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HexaVerticalSlice.BC.FeedDisplay.Infra;

[Table("Invitation")]
public class InvitationEntity
{
    [Key] public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid TargetId { get; set; }
    public DateTime RequestDate { get; set; }
}