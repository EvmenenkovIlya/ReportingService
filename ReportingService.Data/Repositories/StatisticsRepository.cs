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

    public async Task<List<StatisticsDto>> GetStatisticByPeriod(DateTime dateFrom, DateTime dateTo)
    {
        var accountsStatistic = await _accountsStatisticsRepository.GetStatisticByPeriod(dateFrom, dateTo);
        _logger.LogInformation($"Get statistic by Period from {dateFrom} to {dateTo}");
        var result =  (await Connection.QueryAsync<StatisticsDto>(
            StoredProcedures.Statistic_GetByPeriod,
            param: new { dateFrom, dateTo },
            commandType: CommandType.StoredProcedure)).ToList();
        result.ForEach(x=>x.AccountsStatistics = accountsStatistic[x.DateStatistic]);
        _logger.LogInformation($"Returned {result.Count} statistic");
        return result;
    }
}
