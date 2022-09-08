using IncredibleBackendContracts.Enums;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IAccountsStatisticsRepository
{
    Task AddStatistic(DateTime date, Currency currency);
    Task<List<AccountsStatisticsDto>> GetAllStatistic();
    Task<List<AccountsStatisticsDto>> GetStatisticByDate(DateTime date);
    Task<List<AccountsStatisticsDto>> GetStatisticByPeriod(DateTime dateFrom, DateTime dateTo);
}