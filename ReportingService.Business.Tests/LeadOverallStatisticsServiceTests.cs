
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.Business.Services;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Tests;

public  class LeadOverallStatisticsServiceTests
{
    private readonly Mock<ILeadOverallStatisticsRepository> _mockLeadOverallStatisticRepository;
    private readonly Mock<ILogger<LeadOverallStatisticsService>> _logger;
    private readonly LeadOverallStatisticsService _sut;

    public LeadOverallStatisticsServiceTests()
    {
        _mockLeadOverallStatisticRepository = new Mock<ILeadOverallStatisticsRepository>();
        _logger = new Mock<ILogger<LeadOverallStatisticsService>>();
        _sut = new LeadOverallStatisticsService(_mockLeadOverallStatisticRepository.Object, _logger.Object);
    }

    [Fact]
    public async Task GetLeadIdsWithNecessaryTransactionsCount_WhenValidDate_ListReceived()
    {
        //given
        int transactionsCount = 5;
        int daysCount = 30;
        var date = DateTime.Now.AddDays(-daysCount);
        List<int> expectedResult = new List<int>() { 1, 2, 3 };
        _mockLeadOverallStatisticRepository.Setup(o => o.GetLeadIdsWithNecessaryTransactionsCount(It.Is<int>(x => x == transactionsCount), It.Is<DateTime>(x => x.Date == date.Date))).ReturnsAsync(expectedResult);

        //when
        var actual = await _sut.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, daysCount);

        //then
        _mockLeadOverallStatisticRepository.Verify(o => o.GetLeadIdsWithNecessaryTransactionsCount(It.Is<int>(x => x == transactionsCount), It.Is<DateTime>(x => x.Date == date.Date)), Times.Once);
        Assert.All(actual, i => Assert.Contains(i, expectedResult));
    }

    [Fact]
    public async Task GetLeadsIdsWithNecessaryAmountDifference_WhenValidDate_ListReceived()
    {
        //given
        decimal amountDifference = 1200;
        int daysCount = 30;
        var date = DateTime.Now.AddDays(-daysCount);
        List<int> expectedResult = new List<int>() { 1, 2, 3 };
        _mockLeadOverallStatisticRepository.Setup(o => o.GetLeadsIdsWithNecessaryAmountDifference(It.Is<decimal>(x => x == amountDifference), It.Is<DateTime>(x => x.Date == date.Date))).ReturnsAsync(expectedResult);

        //when
        var actual = await _sut.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, daysCount);

        //then
        _mockLeadOverallStatisticRepository.Verify(o => o.GetLeadsIdsWithNecessaryAmountDifference(It.Is<decimal>(x => x == amountDifference), It.Is<DateTime>(x => x.Date == date.Date)), Times.Once);
        Assert.All(actual, i => Assert.Contains(i, expectedResult));
    }
}
