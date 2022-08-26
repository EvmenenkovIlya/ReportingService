using Dapper;
using ReportingService.Data.Dto;
using System.Data;

namespace ReportingService.Data.Repositories;

public class TransactionsRepositiry : BaseRepositories, ITransactionsRepositiry
{
    public TransactionsRepositiry(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task<TransactionDto> GetTransactionById(int id)
    {
        return await Connection.QuerySingleAsync<TransactionDto>(
                StoredProcedures.Transaction_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
    }

    public async Task<List<TransactionDto>> GetAllTransactions()
    {
        return (await Connection.QueryAsync<TransactionDto>
                (StoredProcedures.Transaction_GetAll,
                   commandType: System.Data.CommandType.StoredProcedure))
                   .ToList();
    }
}
