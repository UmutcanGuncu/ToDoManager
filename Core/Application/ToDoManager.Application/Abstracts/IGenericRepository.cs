namespace ToDoManager.Application.Abstracts;

public interface IGenericRepository <T> where T: class
{
    public void Add(T t);
    public List<T> GetAll();
    public T GetById(int id);
    public void Update(T t);
    public void Delete(int id);
}