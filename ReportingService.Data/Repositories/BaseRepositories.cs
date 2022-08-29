using System.Data.SqlClient;
using System.Data;

namespace ReportingService.Data;
public class BaseRepositories
{
    public IDbConnection _connection;

    public BaseRepositories(IDbConnection dbConnection)
    {
        _connection = dbConnection;
    }

    public IDbConnection Connection => new SqlConnection(_connection.ConnectionString);
}
