using Dapper;
using ReportingService.Data.Dto;
using System.Data;
using IncredibleBackendContracts.Enums;
using Microsoft.Extensions.Logging;

namespace ReportingService.Data.Repositories;

public class AccountsRepository : BaseRepositories, IAccountsRepository
{
    private  readonly ILogger<AccountsRepository> _logger;

    public AccountsRepository(IDbConnection dbConnection, ILogger<AccountsRepository> logger)
        : base(dbConnection)
    {
        _logger = logger;
    }

    public async Task AddAccount(AccountDto accountDto)
    {
        _logger.LogInformation($"DataLayer: add new account with accountId = {accountDto.AccountId}, leadId = {accountDto.LeadId}");
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
        _logger.LogInformation($"DataLayer: try get all accounts");
        var result = (await Connection.QueryAsync<AccountDto>
            (StoredProcedures.Account_GetAll, commandType: CommandType.StoredProcedure)).ToList();
        _logger.LogInformation($"DataLayer: Return {result.Count} accounts");
        return result;
    }

    public async Task DeleteAccount(int id)
    {
        _logger.LogInformation($"DataLayer: delete account with accountId {id}");
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
        _logger.LogInformation($"DataLayer: get account with accountId {accountId}");
        return await Connection.QuerySingleOrDefaultAsync<AccountDto>(
                StoredProcedures.Account_GetById,
                param: new { AccountId = accountId },
                commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAccount(int accountId, AccountStatus status)
    {
        _logger.LogInformation($"DataLayer: Update account's status with accountId {accountId} to status {status}");
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
