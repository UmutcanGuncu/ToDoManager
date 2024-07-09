using ToDoManager.Application.Abstracts;
using ToDoManager.Persistence.Context;

namespace ToDoManager.Persistence.Concretes;

public class GenericService<T> : IGenericRepository<T> where T: class
{
    private readonly ToDoManagerDbContext _context;

    public GenericService(ToDoManagerDbContext context)
    {
        _context = context;
    }

    public void Add(T t)
    {
        _context.Set<T>().Add(t);
        _context.SaveChanges();
    }

    public List<T> GetAll()
    {
        var values = _context.Set<T>().ToList();
        return values;
    }

    public T GetById(int id)
    {
        var value = _context.Set<T>().Find(id);
        return value;
    }

    public void Update(T t)
    {
        _context.Set<T>().Update(t);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var value =_context.Set<T>().Find(id);
        _context.Remove(value);
        _context.SaveChanges();
    }
}