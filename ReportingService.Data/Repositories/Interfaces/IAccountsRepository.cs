using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IAccountsRepository
{
    void AddAccount(AccountDto accountDto);
    List<AccountDto> GetAllAccountDto();
    AccountDto GetAccountDtoById(int id);
    void UpdateAccount(AccountDto accountDto);
}
