using Das.Application.Interfaces;

namespace Das.Data.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<IReadOnlyList<T>> FindAsync(string sql)
        {
            throw new NotImplementedException();
        }

        public Task<T?> FindByIdAsync(long id, string storedProcedure)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }
    }


}
