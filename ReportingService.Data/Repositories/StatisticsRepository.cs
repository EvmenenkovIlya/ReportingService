using System.Data;
using Dapper;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public class StatisticsRepository : BaseRepositories, IStatisticsRepository
{
    public StatisticsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task AddStatistic(StatisticsDto StatisticDto)
    {
        await Connection.QuerySingleAsync
                   (StoredProcedures.Statistic_Add,
                   param: new
                   {
                       StatisticDto.Currency,
                       StatisticDto.ActiveAccountCount,
                       StatisticDto.AllAccountCount,
                       StatisticDto.ActiveLeadCount,
                       StatisticDto.DateStatistic,
                       StatisticDto.VipCount
                   },
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

    public async Task<StatisticsDto> GetStatisticById(int id)
    {
        return await Connection.QuerySingleAsync<StatisticsDto>(
                StoredProcedures.Statistic_GetById,
                param: new { id },
                commandType: CommandType.StoredProcedure
                );
    }
}
