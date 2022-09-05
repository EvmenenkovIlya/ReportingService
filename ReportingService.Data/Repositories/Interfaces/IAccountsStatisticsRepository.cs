using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IAccountsStatisticsRepository
{
    Task AddStatistic(AccountsStatisticsDto accountsStatisticsDto);
    Task<List<AccountsStatisticsDto>> GetAllStatistic();
    Task<AccountsStatisticsDto> GetStatisticByDate(DateTime date);
}