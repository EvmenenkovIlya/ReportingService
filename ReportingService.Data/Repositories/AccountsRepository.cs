using Dapper;
using ReportingService.Data.Dto;
using System.Data;

namespace ReportingService.Data.Repositories;

public class AccountsRepository : BaseRepositories, IAccountsRepository
{
    public AccountsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task AddAccount(AccountDto accountDto)
    {
        await Connection.QuerySingleAsync
                   (StoredProcedures.Account_Add,
                   param: new
                   {
                       accountDto.LeadId,
                       accountDto.Currency,
                       accountDto.Status
                   },
                   commandType: CommandType.StoredProcedure
                   );
    }

    public async Task<List<AccountDto>> GetAllAccounts()
    {
        return (await Connection.QueryAsync<AccountDto>
            (StoredProcedures.Account_GetAll, commandType: CommandType.StoredProcedure)).ToList();
    }

    //public async Task<int> Account_GetCountByCurrency(List<Currency> currencies)
    //{
    //        new NotImplementedException();
    //        return 1;
    //}

    public async Task<AccountDto> GetAccountById(int id)
    {
        return await Connection.QuerySingleAsync<AccountDto>(
                StoredProcedures.Account_GetById,
                param: new { id },
                commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAccount(AccountDto accountDto)
    {
        await Connection.QuerySingleOrDefaultAsync(
            StoredProcedures.Account_Update,
                param: new
                {
                    accountDto.Id,
                    accountDto.LeadId,
                    accountDto.Currency,
                    accountDto.Status
                },
                commandType: CommandType.StoredProcedure);
    }
}
