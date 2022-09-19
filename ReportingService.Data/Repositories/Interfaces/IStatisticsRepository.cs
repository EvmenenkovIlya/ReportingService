using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IStatisticsRepository
{
    Task AddStatistic();
    Task<List<StatisticsDto>> GetStatisticByPeriod(DateTime dateFrom, DateTime dateTo);
}