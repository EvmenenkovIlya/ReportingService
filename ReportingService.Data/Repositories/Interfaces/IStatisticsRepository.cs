using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IStatisticsRepository
{
    public void AddStatistic(StatisticDto StatisticDto);
    public List<StatisticDto> GetAllStatisticDto();
    public StatisticDto GetStatisticDtoById(int id);
}