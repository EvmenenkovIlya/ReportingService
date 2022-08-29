using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IStatisticsRepository
{
    Task AddStatistic(StatisticsDto StatisticDto);
    Task<List<StatisticsDto>> GetAllStatisticDto();
    Task<StatisticsDto> GetStatisticDtoById(int id);
}