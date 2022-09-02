
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.Business.Services;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Tests;

public  class LeadOverallStatisticsServiceTests
{
    private readonly Mock<ILeadOverallStatisticsRepository> _mockleadOverallStatisticRepository;
    private readonly Mock<ILogger<LeadOverallStatisticsService>> _logger;
    private readonly LeadOverallStatisticsService _sut;

    public LeadOverallStatisticsServiceTests()
    {
        _mockleadOverallStatisticRepository = new Mock<ILeadOverallStatisticsRepository>();
        _logger = new Mock<ILogger<LeadOverallStatisticsService>>();
        _sut = new LeadOverallStatisticsService(_mockleadOverallStatisticRepository.Object, _logger.Object);
    }

    [Fact]
    public async Task GetLeadIdsWithNecessaryTransactionsCount_WhenValidDate_ListReceived()
    {
        //given
        int transactionsCount = 5;
        int daysCount = 30;
        var date = DateTime.Now.AddDays(-daysCount);
        List<int> expectedResult = new List<int>() { 1, 2, 3 };
        _mockleadOverallStatisticRepository.Setup(o => o.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, date)).ReturnsAsync(expectedResult);

        //when
        var actual = await _sut.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, daysCount);

        //then
        _mockleadOverallStatisticRepository.Verify(o => o.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, date), Times.Once);
        Assert.All(actual, i => Assert.Contains(i, expectedResult));
    }

    [Fact]
    public async Task GetLeadsIdsWithNecessaryAmountDifference_WhenValidDate_ListReceived()
    {
        //given
        int amountDifference = 1200;
        int daysCount = 30;
        var date = DateTime.Now.AddDays(-daysCount);
        List<int> expectedResult = new List<int>() { 1, 2, 3 };
        _mockleadOverallStatisticRepository.Setup(o => o.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, date)).ReturnsAsync(expectedResult);

        //when
        var actual = await _sut.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, daysCount);

        //then
        _mockleadOverallStatisticRepository.Verify(o => o.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, date), Times.Once);
        Assert.All(actual, i => Assert.Contains(i, expectedResult));
    }
}
