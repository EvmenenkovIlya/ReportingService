using System.Data;
using Dapper;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public class StatisticsRepository : BaseRepositories, IStatisticsRepository
{
    public StatisticsRepository(IDbConnection dbConnection)
        : base(dbConnection) { }

    public async Task AddStatistic(StatisticDto StatisticDto)
    {
        await Connection.QuerySingleAsync
                   (StoredProcedures.Statistic_Add,
                   param: new
                   {
                       Сurrency = StatisticDto.Сurrency,
                       ActiveAccountCount = StatisticDto.ActiveAccountCount,
                       AllAccountCount = StatisticDto.AllAccountCount,
                       ActiveLeadCount = StatisticDto.ActiveLeadCount,
                       DateStatistic = StatisticDto.DateStatistic,
                   },
                   commandType: System.Data.CommandType.StoredProcedure
                   );
    }

    public async Task<List<StatisticDto>> GetAllStatisticDto()
    {
        return (await Connection.QueryAsync<StatisticDto>
                (StoredProcedures.Statistic_GetAll,
                   commandType: System.Data.CommandType.StoredProcedure))
                   .ToList();
    }

    public async Task<StatisticDto> GetStatisticDtoById(int id)
    {
        return await Connection.QuerySingleAsync<StatisticDto>(
                StoredProcedures.Statistic_GetById,
                param: new { id = id },
                commandType: System.Data.CommandType.StoredProcedure
                );
    }
}
