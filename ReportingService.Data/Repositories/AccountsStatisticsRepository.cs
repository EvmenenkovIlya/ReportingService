using System.Collections.Generic;
using System.Data;
using Dapper;
using IncredibleBackendContracts.Enums;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public class AccountsStatisticsRepository : BaseRepositories, IAccountsStatisticsRepository
{
    public AccountsStatisticsRepository(IDbConnection dbConnection)
            : base(dbConnection) { }

    public async Task AddStatistic(DateTime date, TradingCurrency currency)
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

    public async Task<Dictionary<DateTime, List<AccountsStatisticsDto>>> GetStatisticByPeriod(DateTime dateFrom, DateTime dateTo)
    {
        var result = (await Connection.QueryAsync<AccountsStatisticsDto>
        (StoredProcedures.AccountsStatistic_GetByPeriod,
            param: new { dateFrom, dateTo },
            commandType: CommandType.StoredProcedure)).ToList();
        var dict = result.GroupBy(x => x.DateStatistic).ToDictionary(g => g.Key, g => g.ToList());
        return dict;
    }
}
