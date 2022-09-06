using IncredibleBackendContracts.Enums;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Services;

public class StatisticsService : IStatisticsService
{
    private readonly ILogger<StatisticsService> _logger;
    private readonly IStatisticsRepository _statisticsRepository;
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IAccountsStatisticsRepository _accountsStatisticsRepository;

    public StatisticsService(ILogger<StatisticsService> logger,
        IStatisticsRepository statisticsRepository, ITransactionsRepository transactionsRepository,
        IAccountsStatisticsRepository accountsStatisticsRepository)
    {
        _logger = logger;
        _statisticsRepository = statisticsRepository;
        _transactionsRepository = transactionsRepository;
        _accountsStatisticsRepository = accountsStatisticsRepository;
    }

    public async Task CreateAccountStatistics()
    {
        var listCurrency = Enum.GetValues(typeof(Currency)).OfType<Currency>().ToList();
        await Task.WhenAll(listCurrency.Select(async currency =>
        {
            await _accountsStatisticsRepository.AddStatistic(DateTime.Now.AddDays(-1), currency);
        }));

    }
}
