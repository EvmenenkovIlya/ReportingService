using Dapper;
using ReportingService.Data.Dto;
using System.Data;
using IncredibleBackendContracts.Enums;

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
                       accountDto.AccountId,
                       accountDto.Currency,
                       accountDto.Status,
                       accountDto.LeadId
                   },
                   commandType: CommandType.StoredProcedure
                   );
    }

    public async Task<List<AccountDto>> GetAllAccounts()
    {
        return (await Connection.QueryAsync<AccountDto>
            (StoredProcedures.Account_GetAll, commandType: CommandType.StoredProcedure)).ToList();
    }

    public async Task DeleteAccount(int id)
    {
        await Connection.QuerySingleOrDefaultAsync(
            StoredProcedures.Account_Delete,
            param: new
            {
                AccountId = id
            },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<AccountDto> GetAccountById(int accountId)
    {
        return await Connection.QuerySingleOrDefaultAsync<AccountDto>(
                StoredProcedures.Account_GetById,
                param: new { AccountId = accountId },
                commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAccount(int accountId, AccountStatus status)
    {
        await Connection.QuerySingleOrDefaultAsync(
            StoredProcedures.Account_Update,
                param: new
                {
                    AccountId = accountId,
                    Status = status
                },
                commandType: CommandType.StoredProcedure);
    }
}
