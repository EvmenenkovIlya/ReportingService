using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IStatisticsRepository
{
    Task AddStatistic(StatisticDto StatisticDto);
    Task<List<StatisticDto>> GetAllStatisticDto();
    Task<StatisticDto> GetStatisticDtoById(int id);
}