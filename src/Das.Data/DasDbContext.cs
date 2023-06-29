using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Das.Data;

public class DasDbContext : IDasDbContext
{
    private readonly string _connectionString = "";


    public DasDbContext(IConfiguration? configuration)
    {
        if (configuration == null) return;
        _connectionString = configuration.GetConnectionString("SqlConnection")!;
    }


    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
