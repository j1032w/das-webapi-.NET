using System.Data;

namespace Das.Data;

public interface IDasDbContext
{
    public IDbConnection CreateConnection();
}
