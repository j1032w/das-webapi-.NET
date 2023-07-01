using System.Data;
using Dapper;
using Das.Application.Interfaces;
using Das.Application.ResidentialProperties;
using Das.Domain.Entities;

namespace Das.Data.repositories;

public class ResidentialPropertyRepository : IResidentialPropertyRepository
{
    private readonly IDasDbContext _dbContext;


    public ResidentialPropertyRepository(IDasDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<ResidentialProperty>> GetAllAsync()
    {
        using var connection = _dbContext.CreateConnection();
        connection.Open();
        var result = await connection.QueryAsync<ResidentialProperty>(
            "GetAllResidentialProperties",
            commandType: CommandType.StoredProcedure);

        // AsList() is a custom Dapper extension method.
        // AsList() returns it back, just casts to List<T>. If it's not - it calls regular ToList.
        // AsList() avoid the creation of copy if the result is already a list.
        // C# build-in ToList() always creates a copy.
        // Without AsList(), the code runs the risk of remunerating through the result set multiple times,
        return result.AsList();
    }

    public Task<ResidentialProperty> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<string> AddAsync(ResidentialProperty entity)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateAsync(ResidentialProperty entity)
    {
        throw new NotImplementedException();
    }

    public Task<string> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }
   
}
