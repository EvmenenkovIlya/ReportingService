using IncredibleBackendContracts.Enums;
using MassTransit.Internals;
using Microsoft.Extensions.Logging;
using Quartz;
using ReportingService.Business.Models;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Services;

public class StatisticsService : IStatisticsService, IJob
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

    public async Task Execute()
    {
        await Task.WhenAll(
            CreateAccountStatistics(),
            CreateLeadsCountStatistics()
        );
    }

    public async Task CreateAccountStatistics()
    {
        var listCurrencies = Enum.GetValues(typeof(TradingCurrency)).OfType<TradingCurrency>().ToList();
        await Task.WhenAll(listCurrencies.Select(async currency =>
        {
            await _accountsStatisticsRepository.AddStatistic(DateTime.Now.AddDays(-1), currency);
        }));
    }

    public async Task CreateLeadsCountStatistics()
    {
        await _statisticsRepository.AddStatistic();
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await Task.WhenAll(
            CreateAccountStatistics(),
            CreateLeadsCountStatistics()
        );
    }
}
