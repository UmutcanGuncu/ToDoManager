using ToDoManager.Application.Abstracts;
using ToDoManager.Domain.Entities;
using ToDoManager.Persistence.Context;


namespace ToDoManager.Persistence.Concretes;

public class CheckpointService : GenericService<Checkpoint>,ICheckpointRepository
{
    public CheckpointService(ToDoManagerDbContext context) : base(context)
    {
    }
}