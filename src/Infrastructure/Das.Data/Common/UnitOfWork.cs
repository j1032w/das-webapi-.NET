using Das.Application.Interfaces;
using System.Data.Common;

namespace Das.Data.Common;

public class UnitOfWork : IUnitOfWork, IDisposable
{

    private readonly DbConnection _dbConnection;
    private DbTransaction _dbTransaction;


    public DbConnection DbConnection => _dbConnection;
    public DbTransaction DbTransaction => _dbTransaction;




    public UnitOfWork(IDbContext dbContext)
    {
        _dbConnection = dbContext.CreateConnection();
        _dbConnection.Open();
        _dbTransaction = BeginTransaction();

    }


    public DbTransaction BeginTransaction()
    {
        _dbTransaction = _dbConnection.BeginTransaction();
        return _dbTransaction;
    }


    public void RollbackTransaction()
    {
        _dbTransaction.Rollback();
    }


    public Task BeginAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _dbTransaction.CommitAsync();
            // By adding this we can have multiple transactions as part of a single request
            await _dbConnection.BeginTransactionAsync();
        }
        catch (Exception ex)
        {
            await _dbTransaction.RollbackAsync();

        }
    }

    public void Dispose()
    {
        _dbConnection?.Close();
        _dbConnection?.Dispose();
        _dbTransaction?.Dispose();
    }



    public async Task RollbackAsync()
    {
        await _dbTransaction.RollbackAsync();
    }

}
