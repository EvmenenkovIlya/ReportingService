using System.Data.SqlClient;
using System.Data;

namespace ReportingService.Data;
public class BaseRepositories
{
    private IDbConnection _connection;

    public BaseRepositories(IDbConnection dbConnection)
    {
        _connection = dbConnection;
    }

    protected IDbConnection Connection => new SqlConnection(_connection.ConnectionString);
}
