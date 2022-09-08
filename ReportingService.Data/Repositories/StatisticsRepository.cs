using System.Data;
using Dapper;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public class StatisticsRepository : BaseRepositories, IStatisticsRepository
{
    public StatisticsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task AddStatistic()
    {
        await Connection.QuerySingleAsync
                   (StoredProcedures.Statistic_Add,
                       commandType: CommandType.StoredProcedure
                   );
    }

    public async Task<List<StatisticsDto>> GetAllStatistic()
    {
        return (await Connection.QueryAsync<StatisticsDto>
                (StoredProcedures.Statistic_GetAll,
                   commandType: CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task<StatisticsDto> GetStatisticByDate(DateTime date)
    {
        return await Connection.QuerySingleAsync<StatisticsDto>(
                StoredProcedures.Statistic_GetByDate,
                param: new { date },
                commandType: CommandType.StoredProcedure
                );
    }

    public async Task<List<StatisticsDto>> GetStatisticByPeriod(DateTime dateFrom, DateTime dateTo)
    {
        return (await Connection.QueryAsync<StatisticsDto>(
            StoredProcedures.Statistic_GetByPeriod,
            param: new { dateFrom, dateTo },
            commandType: CommandType.StoredProcedure)).ToList();
    }
}
