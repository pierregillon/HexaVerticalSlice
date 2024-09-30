using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HexaVerticalSlice.BC.FeedComputation.Infra.Database.Models;

[Table("Post")]
public class PostEntity
{
    [Key] public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public Guid ProfileId { get; set; }
    public DateTime PublishDate { get; set; }
    public Guid UserId { get; set; }
    public virtual ICollection<ThreadEntity> Threads { get; set; } = default!;
}