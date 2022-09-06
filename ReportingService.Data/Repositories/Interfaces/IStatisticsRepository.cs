using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IStatisticsRepository
{
    Task AddStatistic(StatisticsDto statisticDto);
    Task<List<StatisticsDto>> GetAllStatistic();
    Task<StatisticsDto> GetStatisticByDate(DateTime date);
}