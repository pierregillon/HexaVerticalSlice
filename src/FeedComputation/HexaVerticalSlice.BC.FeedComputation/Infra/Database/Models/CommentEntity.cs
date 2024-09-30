using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HexaVerticalSlice.BC.FeedComputation.Infra.Database.Models;

[Table("Comment")]
public class CommentEntity
{
    [Key] public Guid Id { get; set; }
    public Guid ThreadId { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public Guid ProfileId { get; set; }
    public virtual ThreadEntity? Thread { get; set; }
}