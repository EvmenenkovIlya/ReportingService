using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Services;

public class StatisticsService
{
    private readonly ILogger<StatisticsService> _logger;
    private readonly IStatisticsRepository _statisticsRepository;

    public StatisticsService(ILogger<StatisticsService> logger, StatisticsRepository statisticsRepository)
    {
        _logger = logger;
        _statisticsRepository = statisticsRepository;
    }

    public async Task CreateStatistics()
    {
        // sum
        //public DateTime DateStatistics { get; set; }
        //public Currency Сurrency { get; set; }
        //public long ActiveAccountsCount { get; set; }
        //public long AllAccountsCount { get; set; }
        //public long ActiveLeadsCount { get; set; }

        var st = new Statistics() { DateStatistics = DateTime.Now };
        //await Task.WhenAll(listStatistic.Select(async st =>
        //{
        //    var list = await _statisticsRepository.AddStatistic(st);
        //    return list;
        //}));
    }
}
