

using ReportingService.Business.Models;

namespace ReportingService.Business.Services;

public interface ITransactionsService
{
    Task AddTransaction(Transaction transaction);
}
