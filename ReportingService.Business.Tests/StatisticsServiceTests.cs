using AutoMapper;
using IncredibleBackendContracts.Enums;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.Business.Exceptions;
using ReportingService.Business.Services;
using ReportingService.Data.Dto;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Tests;

public class StatisticsServiceTests
{
    private readonly Mock<ILogger<StatisticsService>> _mockLogger;
    private readonly Mock<IStatisticsRepository> _mockStatisticsRepository;
    private readonly Mock<IAccountsStatisticsRepository> _mockAccountsStatisticsRepository;

    private readonly StatisticsService _sut;
    private readonly IMapper _mapper;

    public StatisticsServiceTests()
    {
        _mockLogger = new Mock<ILogger<StatisticsService>>();
        _mockStatisticsRepository = new Mock<IStatisticsRepository>();
        _mockAccountsStatisticsRepository = new Mock<IAccountsStatisticsRepository>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _sut = new StatisticsService(_mockLogger.Object, _mockStatisticsRepository.Object,
            _mockAccountsStatisticsRepository.Object, _mapper);
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

    [Fact]
    public async Task GetStatistics_WhenDateFromMoreThanDateTo_ThrowBadRequestException()
    {
        //given
        var dateFrom = DateTime.Now;
        var dateTo = DateTime.Now.AddDays(-1);

        //when

        //then
        await Assert.ThrowsAsync<BadRequestException>(() => _sut.GetStatisticsByPeriod(dateFrom, dateTo));
    }

    [Fact]
    public async Task GetStatistics_WhenValidDatesPassed_StatisticReturned()
    {
        //given
        var dateFrom = DateTime.Now.AddDays(-1);
        var dateTo = DateTime.Now;
        var dates = new List<DateTime>() { dateFrom, dateTo };
        var statisticsDto = new List<StatisticsDto>() { 
            new()
            {
                DateStatistic = dateFrom,
                RegularLeadsCount = 1,
                VipLeadsCount = 2,
                DeletedLeadsCount = 3,
                DeletedVipsCount = 4,
                AccountsStatistics = new List<AccountsStatisticsDto>()
                {
                    new ()
                    {
                        Currency = Currency.RUB,
                        ActiveAccountCount = 5,
                        DateStatistic = dateFrom,
                        DeletedAccountCount = 5,
                        FrozenAccountCount = 5
                    },
                    new ()
                    {
                        Currency = Currency.USD,
                        ActiveAccountCount = 6,
                        DateStatistic = dateFrom,
                        DeletedAccountCount = 6,
                        FrozenAccountCount = 6
                    }
                }
            },
            new()
            {
                DateStatistic = dateTo,
                RegularLeadsCount = 2,
                VipLeadsCount = 3,
                DeletedLeadsCount = 4,
                DeletedVipsCount = 5,
                AccountsStatistics = new List<AccountsStatisticsDto>()
                {
                    new ()
                    {
                        Currency = Currency.RUB,
                        ActiveAccountCount = 6,
                        DateStatistic = dateTo,
                        DeletedAccountCount = 6,
                        FrozenAccountCount = 6
                    },
                    new ()
                    {
                        Currency = Currency.USD,
                        ActiveAccountCount = 7,
                        DateStatistic = dateTo,
                        DeletedAccountCount = 7,
                        FrozenAccountCount = 7
                    }
                }
            },

        };
        _mockStatisticsRepository.Setup(o => o.GetStatisticByPeriod(dates)).ReturnsAsync(statisticsDto);

        //when
        var result = await _sut.GetStatisticsByPeriod(dateFrom, dateTo);

        //then
        //Assert.Multiple(() =>
        //{
        //    Assert.Equal(statisticsDto.Count/2, result.Count);

        //});
        _mockStatisticsRepository.Verify(o => o.GetStatisticByPeriod(It.Is<List<DateTime>>(x => x.Count == dates.Count)), Times.Once);
    }

}

