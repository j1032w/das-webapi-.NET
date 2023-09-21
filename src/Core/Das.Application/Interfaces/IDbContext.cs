using System.Data.Common;

namespace Das.Application.Interfaces;

public interface IDbContext
{
    public DbConnection CreateConnection();


}
