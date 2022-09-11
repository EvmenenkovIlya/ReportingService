using IncredibleBackendContracts.Enums;
using ReportingService.Business.Models;

namespace ReportingService.Business.Services;

public interface IAccountsService
{
    Task AddAccount(Account account);
    Task<List<Account>> GetAllAccounts();
    Task<Account> GetAccountById(int id);
    Task DeleteAccount(int accountId);
    Task UpdateAccount(int accountId, AccountStatus status);
}