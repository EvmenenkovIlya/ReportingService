using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IAccountsRepository
{
    Task AddAccount(AccountDto accountDto);
    Task<List<AccountDto>> GetAllAccounts();
    Task<AccountDto> GetAccountById(int id);
    Task UpdateAccount(AccountDto accountDto);
}
