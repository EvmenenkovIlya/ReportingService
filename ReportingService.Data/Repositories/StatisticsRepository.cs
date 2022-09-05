﻿using System.Data;
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
                       StatisticDto.AllLeadsCount,
                       StatisticDto.VipLeadsCount,
                       StatisticDto.DeletedLeadsCount,
                       StatisticDto.DeletedVipsCount,
                       StatisticDto.DateStatistic
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

    public async Task<StatisticsDto> GetStatisticByDate(DateTime date)
    {
        return await Connection.QuerySingleAsync<StatisticsDto>(
                StoredProcedures.Statistic_GetByDate,
                param: new { date },
                commandType: CommandType.StoredProcedure
                );
    }
}
