namespace Das.Application.Interfaces;

public interface IRepository<T> where T : class {
    Task<IReadOnlyList<T>> FindAsync();
    Task<T?> FindByIdAsync(long id, string storedProcedure);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(long id);
}