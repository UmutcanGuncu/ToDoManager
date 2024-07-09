using System.Collections;
using ToDoManager.Domain.Common;


namespace ToDoManager.Domain.Entities;

public class Checkpoint :BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Server> Servers { get; set; }
    public ICollection<Log> Logs { get; set; }
    
}