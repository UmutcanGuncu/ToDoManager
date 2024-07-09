using ToDoManager.Application.Abstracts;
using ToDoManager.Domain.Entities;
using ToDoManager.Persistence.Context;

namespace ToDoManager.Persistence.Concretes;

public class LogService : GenericService<Log>, ILogRepository
{
    public LogService(ToDoManagerDbContext context) : base(context)
    {
    }
}