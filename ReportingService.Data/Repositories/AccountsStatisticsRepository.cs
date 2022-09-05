using System.Data;
using Dapper;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public class AccountsStatisticsRepository : BaseRepositories, IAccountsStatisticsRepository
{
    public AccountsStatisticsRepository(IDbConnection dbConnection)
            : base(dbConnection) { }

    public async Task AddStatistic(AccountsStatisticsDto AccountsStatisticsDto)
    {
        await Connection.QuerySingleAsync
        (StoredProcedures.AccountsStatistic_Add,
            param: new
            {
                AccountsStatisticsDto.DateStatistic,
                AccountsStatisticsDto.ActiveAccountCount,
                AccountsStatisticsDto.DeletedAccountCount,
                AccountsStatisticsDto.FrozenAccountCount,
                AccountsStatisticsDto.Currency
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<List<AccountsStatisticsDto>> GetAllStatistic()
    {
        return (await Connection.QueryAsync<AccountsStatisticsDto>
            (StoredProcedures.AccountsStatistic_GetAll,
                commandType: CommandType.StoredProcedure))
            .ToList();
    }

    public async Task<AccountsStatisticsDto> GetStatisticByDate(DateTime date)
    {
        return await Connection.QuerySingleAsync<AccountsStatisticsDto>(
            StoredProcedures.AccountsStatistic_GetByDate,
            param: new { date },
            commandType: CommandType.StoredProcedure
        );
    }
}
