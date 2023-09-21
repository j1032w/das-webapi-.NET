using Das.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;

namespace Das.Data.Common;

public class DbContext : IDbContext
{
    private readonly DatabaseOption _databaseOption;


    // Configure Options Pattern
    // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-7.0
    public DbContext(IConfiguration? configuration)
    {
        _databaseOption = new DatabaseOption();
        configuration?.GetSection(DatabaseOption.DatabaseConfigureSection).Bind(_databaseOption);

        if (string.IsNullOrEmpty(_databaseOption?.ConnectionString))
        {
            throw new ArgumentNullException(nameof(_databaseOption.ConnectionString));
        }
    }



    public DbConnection CreateConnection()
    {
        switch (_databaseOption.DatabaseType)
        {
            case "SqlServer":
                return new SqlConnection(_databaseOption.ConnectionString);

            default:
                return new OracleConnection(_databaseOption.ConnectionString);

        }

    }
}
