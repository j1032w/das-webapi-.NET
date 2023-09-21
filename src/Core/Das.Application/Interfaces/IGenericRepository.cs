namespace Das.Application.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> FindAsync(string sql);
    public Task<T?> FindByIdAsync(long id, string storedProcedure);
    public Task<T> AddAsync(T entity);
    public Task<T> UpdateAsync(T entity);
    public Task DeleteAsync(long id);
}