namespace Spender.DAL.Interfaces;
public interface IRepository<T> : IDisposable where T : class
{
    IEnumerable<T> GetItemList();
    T? GetItem(Guid name);
    T Create(T item);
    void Update(T item);
    void Delete(Guid id); 
    void Save();
}