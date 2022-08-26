using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface ITransactionsRepositiry
{
    TransactionDto GetTransactionById(int id);
    List<TransactionDto> GetAllTransactions();
}