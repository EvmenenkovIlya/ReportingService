using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public class StatisticsRepository : BaseRepositories, IStatisticsRepository
{
    private readonly ILogger<StatisticsRepository> _logger;
    private readonly IAccountsStatisticsRepository _accountsStatisticsRepository;

    public StatisticsRepository(IDbConnection dbConnection, ILogger<StatisticsRepository> logger, IAccountsStatisticsRepository accountsStatisticsRepository)
        : base(dbConnection)
    {
        _logger = logger;
        _accountsStatisticsRepository = accountsStatisticsRepository;
    }

    public async Task AddStatistic()
    {
        _logger.LogInformation("Start to write statistic to Database");
        await Connection.QuerySingleAsync
                   (StoredProcedures.Statistic_Add,
                       commandType: CommandType.StoredProcedure
                   );
    }

    public async Task<List<StatisticsDto>> GetStatisticByPeriod(List<DateTime> dates)
    {
        DataTable data = new DataTable();
        data.Columns.Add("Date", typeof(DateTime));
        dates.ForEach(x => data.Rows.Add(x));

        var accountsStatistic = await _accountsStatisticsRepository.GetStatisticByPeriod(dates);
        _logger.LogInformation($"Get statistic by Period from {dates.Min()} to {dates.Min()}");
        var result = (await Connection.QueryAsync<StatisticsDto>(
            StoredProcedures.Statistic_GetByPeriod,
            param: new { Date = data },
            commandType: CommandType.StoredProcedure)).ToList();
        result.ForEach(x => x.AccountsStatistics = accountsStatistic[x.DateStatistic]);
        _logger.LogInformation($"Returned {result.Count} statistic");
        return result;
    }
}
