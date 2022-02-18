namespace danskeND.Repository.Repositories.Common;

public interface IBaseRepository<T> where T: class
{
    Task AddAsync(T entity);
    Task RemoveByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task UpdateAsync(T entity);
}