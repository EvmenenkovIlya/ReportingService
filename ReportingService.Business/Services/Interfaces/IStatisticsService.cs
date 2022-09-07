namespace ReportingService.Business.Services;

public interface IStatisticsService
{
    Task CreateAccountStatistics();
    Task Execute();
}