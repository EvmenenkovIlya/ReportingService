using IncredibleBackendContracts.Enums;
using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface IAccountsStatisticsRepository
{
    Task AddStatistic(DateTime date, TradingCurrency currency);
    Task<Dictionary<DateTime, List<AccountsStatisticsDto>>> GetStatisticByPeriod(DateTime dateFrom, DateTime dateTo);
}