using IncredibleBackendContracts.Enums;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IAccountsRepository
{
    Task AddAccount(AccountDto accountDto);
    Task<List<AccountDto>> GetAllAccounts();
    Task<AccountDto> GetAccountById(int accountId);
    Task DeleteAccount(int id);
    Task UpdateAccount(int accountIs, AccountStatus status);
}
