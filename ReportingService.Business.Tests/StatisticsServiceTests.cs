using IncredibleBackendContracts.Enums;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.Business.Services;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Tests;

public class StatisticsServiceTests
{
    private readonly Mock<ILogger<StatisticsService>> _mockLogger;
    private readonly Mock<IStatisticsRepository> _mockStatisticsRepository;
    private readonly Mock<IAccountsStatisticsRepository> _mockAccountsStatisticsRepository;
    private readonly StatisticsService _sut;

    public StatisticsServiceTests()
    {
        _mockLogger = new Mock<ILogger<StatisticsService>>();
        _mockStatisticsRepository = new Mock<IStatisticsRepository>();
        _mockAccountsStatisticsRepository = new Mock<IAccountsStatisticsRepository>();
        _sut = new StatisticsService(_mockLogger.Object, _mockStatisticsRepository.Object
            , _mockAccountsStatisticsRepository.Object);
    }

    [Fact]
    public async Task CreateAccountStatistics_WhenCall_ExecuteRepositoryMethod()
    {
        //given
        var listCurrencies = Enum.GetValues(typeof(TradingCurrency)).OfType<TradingCurrency>().ToList();

        //when
        await _sut.CreateAccountStatistics();

        //then
        foreach (var currency in listCurrencies)
        {
            _mockAccountsStatisticsRepository.Verify(o => o.AddStatistic(It.Is<DateTime>(x => x.Date == DateTime.Now.AddDays(-1).Date), currency), Times.Once);
        }
    }

    [Fact]
    public async Task CreateLeadsCountStatistics_WhenCall_ExecuteRepositoryMethod()
    {
        //given

        //when
        await _sut.CreateLeadsCountStatistics();

        //then
        _mockStatisticsRepository.Verify(o => o.AddStatistic(), Times.Once);
    }
}

