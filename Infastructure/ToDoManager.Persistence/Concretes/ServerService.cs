using ToDoManager.Application.Abstracts;
using ToDoManager.Domain.Entities;
using ToDoManager.Persistence.Context;

namespace ToDoManager.Persistence.Concretes;

public class ServerService : GenericService<Server>, IServerRepository
{
    public ServerService(ToDoManagerDbContext context) : base(context)
    {
    }
}