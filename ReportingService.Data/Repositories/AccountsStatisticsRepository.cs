using System.Data;
using Dapper;
using IncredibleBackendContracts.Enums;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public class AccountsStatisticsRepository : BaseRepositories, IAccountsStatisticsRepository
{
    public AccountsStatisticsRepository(IDbConnection dbConnection)
            : base(dbConnection) { }

    public async Task AddStatistic(DateTime date, Currency currency)
    {
        await Connection.QuerySingleAsync
        (StoredProcedures.AccountsStatistic_Add,
            param: new
            {
                DateStatistic = date,
                Currency = currency
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

    public async Task<List<AccountsStatisticsDto>> GetStatisticByDate(DateTime date)
    {
        return (await Connection.QueryAsync<AccountsStatisticsDto>
        (StoredProcedures.AccountsStatistic_GetByDate,
            param: new { DatrStatistic = date.Date },
            commandType: CommandType.StoredProcedure)).ToList();
    }

    public async Task<List<AccountsStatisticsDto>> GetStatisticByPeriod(DateTime dateFrom, DateTime dateTo)
    {
        return (await Connection.QueryAsync<AccountsStatisticsDto>
        (StoredProcedures.AccountsStatistic_GetByPeriod,
            param: new { dateFrom, dateTo },
            commandType: CommandType.StoredProcedure)).ToList();
    }
}
