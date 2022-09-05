using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Services;

public class StatisticsService
{
    private readonly ILogger<StatisticsService> _logger;
    private readonly IStatisticsRepository _statisticsRepository;
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IAccountsRepository _accountsRepository;

    public StatisticsService(ILogger<StatisticsService> logger,
        StatisticsRepository statisticsRepository, ITransactionsRepository transactionsRepository, 
        IAccountsRepository accountsRepository)
    {
        _logger = logger;
        _statisticsRepository = statisticsRepository;
        _transactionsRepository = transactionsRepository;
        _accountsRepository = accountsRepository;
    }

    public async Task CreateStatistics()
    {
        var transactionByYesterday = _transactionsRepository.GetTransactionsByYesterday();
        var i = await _accountsRepository.GetAllAccounts();
        //foreach (Currency val in Enum.GetValues(typeof(Currency)))
        //{
            
        //    var st = new Statistics()
        //    {
        //        DateStatistics = DateTime.Now.AddDays(-1),
                
        //        ActiveAccountsCount = i.Where(x => x.Currency == val).Count(),
        //        AllAccountsCount = i.Where(x => x.Currency == val && x.Status == Status.Active).Count()
        //    };
            
        //}
        // sum
        //public DateTime DateStatistics { get; set; }
        //public Currency Сurrency { get; set; }
        //public long ActiveAccountsCount { get; set; }
        //public long AllAccountsCount { get; set; }
        //public long ActiveLeadsCount { get; set; }

        //await Task.WhenAll(listStatistic.Select(async st =>
        //{
        //    var list = await _statisticsRepository.AddStatistic(st);
        //    return list;
        //}));
    }
}
