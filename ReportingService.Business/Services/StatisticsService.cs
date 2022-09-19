using AutoMapper;
using IncredibleBackendContracts.Enums;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Infarstracture;
using ReportingService.Business.Models;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Services;

public class StatisticsService : IStatisticsService
{
    private readonly ILogger<StatisticsService> _logger;
    private readonly IStatisticsRepository _statisticsRepository;
    private readonly IAccountsStatisticsRepository _accountsStatisticsRepository;
    private readonly IMapper _mapper;

    public StatisticsService(ILogger<StatisticsService> logger,
        IStatisticsRepository statisticsRepository,
        IAccountsStatisticsRepository accountsStatisticsRepository,
        IMapper mapper)
    {
        _logger = logger;
        _statisticsRepository = statisticsRepository;
        _accountsStatisticsRepository = accountsStatisticsRepository;
        _mapper = mapper;
    }

    public async Task Execute()
    {
        _logger.LogInformation($"StatisticsService starts working at {DateTime.Now}");
        await Task.WhenAll(
            CreateAccountStatistics(),
            CreateLeadsCountStatistics()
        );
    }

    public async Task<List<Statistics>> GetStatisticsByPeriod(DateTime dateFrom, DateTime dateTo)
    {
        Validator.ValidateDates(dateFrom, dateTo, ExceptionsErrorMessages.DateFromMoreThanDateTo);
        var dates = GetDatesFromDateToDate(dateFrom, dateTo);
        var result = await _statisticsRepository.GetStatisticByPeriod(dates);
        return _mapper.Map<List<Statistics>>(result);
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

    private List<DateTime> GetDatesFromDateToDate(DateTime dateFrom, DateTime dateTo)
    {
        
        return Enumerable.Range(0, (dateTo - dateFrom).Days + 1)
            .Select(i => dateFrom.AddDays(i).Date)
            .ToList();
    }
}
