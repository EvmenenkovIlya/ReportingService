using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface ITransactionsRepository
{
    Task<TransactionDto> GetTransactionById(int id);
    Task<List<TransactionDto>> GetAllTransactions();
}