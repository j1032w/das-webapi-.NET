using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Das.Data.Common
{
    public class OracleRefCursorParam : SqlMapper.ICustomQueryParameter
    {
        public string ParamName { get; }

        public OracleRefCursorParam(string paramName) { ParamName = paramName; }



        public void AddParameter(IDbCommand command, string name)
        {
            if (command.Connection != null && command.Connection.GetType().Name.Equals("OracleConnection", StringComparison.InvariantCultureIgnoreCase))
            {
                var param = new OracleParameter { ParameterName = name, OracleDbType = OracleDbType.RefCursor, Value = null, Direction = ParameterDirection.Output };
                command.Parameters.Add(param);
            }
        }
    }
}
