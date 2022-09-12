using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public class StatisticsRepository : BaseRepositories, IStatisticsRepository
{
    private readonly ILogger<StatisticsRepository> _logger;

    public StatisticsRepository(IDbConnection dbConnection, ILogger<StatisticsRepository> logger)
        : base(dbConnection)
    {
        _logger = logger;
    }

    public async Task AddStatistic()
    {
        _logger.LogInformation("Start to write statistic to Database");
        await Connection.QuerySingleAsync
                   (StoredProcedures.Statistic_Add,
                       commandType: CommandType.StoredProcedure
                   );
    }

    public async Task<List<StatisticsDto>> GetAllStatistic()
    {
        _logger.LogInformation("Get all statistic from Database");
        var result = (await Connection.QueryAsync<StatisticsDto>
                (StoredProcedures.Statistic_GetAll,
                   commandType: CommandType.StoredProcedure))
                   .ToList();
        return result;
    }

    public async Task<StatisticsDto> GetStatisticByDate(DateTime date)
    {
        _logger.LogInformation($"Get statistic from Database from date {date.Date}");
        var result = await Connection.QuerySingleAsync<StatisticsDto>(
                StoredProcedures.Statistic_GetByDate,
                param: new { date },
                commandType: CommandType.StoredProcedure
                );
        return result;
    }

    public async Task<List<StatisticsDto>> GetStatisticByPeriod(DateTime dateFrom, DateTime dateTo)
    {
        _logger.LogInformation("Get statistic by Period");
        var result =  (await Connection.QueryAsync<StatisticsDto>(
            StoredProcedures.Statistic_GetByPeriod,
            param: new { dateFrom, dateTo },
            commandType: CommandType.StoredProcedure)).ToList();
        _logger.LogInformation($"Returned {result.Count} statistic");
        return result;
    }
}
