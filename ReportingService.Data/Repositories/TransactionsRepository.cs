using Dapper;
using ReportingService.Data.Dto;
using System.Data;

namespace ReportingService.Data.Repositories;

public class TransactionsRepository : BaseRepositories, ITransactionsRepository
{
    public TransactionsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task<TransactionDto> GetTransactionById(int id)
    {
        return await Connection.QuerySingleAsync<TransactionDto>(
                StoredProcedures.Transaction_GetById,
                param: new { id = id },
                commandType: CommandType.StoredProcedure
                );
    }

    public async Task<List<TransactionDto>> GetAllTransactions()
    {
        return (await Connection.QueryAsync<TransactionDto>
                (StoredProcedures.Transaction_GetAll,
                   commandType: CommandType.StoredProcedure))
                   .ToList();
    }
}
