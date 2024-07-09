

using ToDoManager.Domain.Common;

namespace ToDoManager.Domain.Entities;

public class Log : BaseEntity
{
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public int ServerId { get; set; }
    public Server Server { get; set; }
    public int CheckpointId { get; set; }
    public Checkpoint Checkpoint { get; set; }
    public DateTime Date { get; set; }
}