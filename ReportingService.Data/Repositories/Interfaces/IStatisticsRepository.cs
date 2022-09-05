using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IStatisticsRepository
{
    Task AddStatistic(StatisticsDto StatisticDto);
    Task<List<StatisticsDto>> GetAllStatistic();
    Task<StatisticsDto> GetStatisticByDate(DateTime date);
}