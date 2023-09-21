using System.Data.Common;

namespace Das.Application.Interfaces;

public interface IUnitOfWork
{
    public DbConnection DbConnection { get; }
    Task BeginAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
