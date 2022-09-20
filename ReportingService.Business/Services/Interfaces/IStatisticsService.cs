using ReportingService.Business.Models;

namespace ReportingService.Business.Services;

public interface IStatisticsService
{
    Task CreateAccountStatistics();
    Task Execute();
    Task<List<Statistics>> GetStatisticsByPeriod(DateTime dateFrom, DateTime dateTo);
}