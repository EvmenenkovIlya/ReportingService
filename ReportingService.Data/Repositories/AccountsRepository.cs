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
                       LeadId = accountDto.LeadId,
                       Currency = accountDto.Currency,
                       Status = accountDto.Status
                   },
                   commandType: System.Data.CommandType.StoredProcedure
                   );
    }

    public async Task<List<AccountDto>> GetAllAccountDto()
    {
        return (await Connection.QueryAsync<AccountDto>
            (StoredProcedures.Account_GetAll, commandType: System.Data.CommandType.StoredProcedure)).ToList();
    }

    public async Task<AccountDto> GetAccountDtoById(int id)
    {
        return await Connection.QuerySingleAsync<AccountDto>(
                StoredProcedures.Account_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task UpdateAccount(AccountDto accountDto)
    {
        await Connection.QuerySingleOrDefaultAsync(
            StoredProcedures.Account_Update,
                param: new
                {
                    Id = accountDto.Id,
                    LeadId = accountDto.LeadId,
                    Currency = accountDto.Currency,
                    Status = accountDto.Status
                },
                commandType: System.Data.CommandType.StoredProcedure);
    }
}
