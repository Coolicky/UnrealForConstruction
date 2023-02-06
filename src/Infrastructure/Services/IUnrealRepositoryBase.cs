using Models;

namespace Infrastructure.Services;

public interface IUnrealRepository<T> where T : class, IEntity
{
    Task<List<T>> GetAll();
    Task<T?> Get(int id);
    Task<T?> Add(T entity);
    Task<T?> Update(T entity);
    Task<bool> Delete(int id);
}