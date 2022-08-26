using Dapper;
using ReportingService.Data.Dto;
using System.Data.SqlClient;

namespace ReportingService.Data.Repositories;

public class TransactionsRepositiry : ITransactionsRepositiry
{
    public string connectionString = ServerOptions.ConnectionOption;

    public TransactionDto GetTransactionById(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            return connection.QuerySingle<TransactionDto>(
                StoredProcedures.Transaction_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
        }
    }

    public List<TransactionDto> GetAllTransactions()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            return connection.Query<TransactionDto>
                (StoredProcedures.Transaction_GetAll,
                   commandType: System.Data.CommandType.StoredProcedure)
                   .ToList();
        }
    }
}
