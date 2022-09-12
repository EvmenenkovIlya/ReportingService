

using ReportingService.Business.Models;

namespace ReportingService.Business.Services.Interfaces;

public interface ITransactionsService
{
    Task AddTransaction(Transaction transaction);
}
