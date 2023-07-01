using System.Data;

namespace Das.Application.Interfaces;

public interface IDasDbContext
{
    public IDbConnection CreateConnection();
}
