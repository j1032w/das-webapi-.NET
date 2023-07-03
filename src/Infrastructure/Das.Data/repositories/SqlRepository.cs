using System.Data;
using Dapper;
using Das.Application.Interfaces;

namespace Das.Data.repositories;

public class SqlRepository<T> : IRepository<T> where T : class {
    private readonly IDasDbContext _dbContext;

    public SqlRepository(IDasDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity) {
        throw new NotImplementedException();
    }

    Task<T> IRepository<T>.UpdateAsync(T entity) {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(long id) {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> FindAsync() {
        throw new NotImplementedException();
    }

    public async Task<T?> FindByIdAsync(long id, string storedProcedure) {
        var parameters = new {Id = id };
        var sql = $"exec {storedProcedure} @Id";

        using var connection = _dbContext.CreateConnection();
        connection.Open();
        IEnumerable<T?> result = await connection.QueryAsync<T>(
            sql,
            parameters
        );
        


        return result.First() ?? null;
    }


    public async Task UpdateAsync(T entity) {
        throw new NotImplementedException();
    }


    public async Task<IReadOnlyList<T>> FindAsync(int id) {
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        var result = await connection.QueryAsync<T>(
            "uspResidentialPropertyGetById",
            id,
            commandType: CommandType.StoredProcedure);

        // AsList() is a custom Dapper extension method.
        // AsList() returns it back, just casts to List<T>. If it's not - it calls regular ToList.
        // AsList() avoid the creation of copy if the result is already a list.
        // C# build-in ToList() always creates a copy.
        // Without AsList(), the code runs the risk of remunerating through the result set multiple times,
        return result.AsList();
    }
}