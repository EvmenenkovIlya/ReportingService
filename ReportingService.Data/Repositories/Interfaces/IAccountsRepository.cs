using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IAccountsRepository
{
    Task AddAccount(AccountDto accountDto);
    Task<List<AccountDto>> GetAllAccountDto();
    Task<AccountDto> GetAccountDtoById(int id);
    Task UpdateAccount(AccountDto accountDto);
}
