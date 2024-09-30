using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HexaVerticalSlice.BC.FeedComputation.Infra.Database.Models;

[Table("Thread")]
public class ThreadEntity
{
    [Key] public Guid Id { get; set; }
    public Guid PostId { get; set; }

    public virtual ICollection<CommentEntity> Comments { get; set; } = default!;

    public virtual PostEntity Post { get; set; } = default!;
}