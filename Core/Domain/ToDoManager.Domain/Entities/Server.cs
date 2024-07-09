using System.Xml;
using ToDoManager.Domain.Common;


namespace ToDoManager.Domain.Entities;

public class Server :BaseEntity
{
    public string? Name { get; set; }
    public string? Ip { get; set; }
    public ICollection<Checkpoint> Checkpoints { get; set; }
    public ICollection<Log> Logs { get; set; }
}