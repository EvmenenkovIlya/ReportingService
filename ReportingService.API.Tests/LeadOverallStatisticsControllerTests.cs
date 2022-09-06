using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.API.Controllers;
using ReportingService.Business.Services;

namespace ReportingService.API.Tests;

public class LeadOverallStatisticsControllerTests
{
    private LeadStatisticsController _sut;
    private Mock<ILeadOverallStatisticsService> _mockLeadOverallStatisticsRepository;
    private Mock<ILogger<LeadStatisticsController>> _logger;
    private IMapper _mapper;

    public LeadOverallStatisticsControllerTests()
    {
        _mockLeadOverallStatisticsRepository = new Mock<ILeadOverallStatisticsService>();
        _logger = new Mock<ILogger<LeadStatisticsController>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _sut = new LeadStatisticsController(_logger.Object, _mockLeadOverallStatisticsRepository.Object);
    }

    [Fact]
    public async Task GetLeadIdsWithNecessaryTransactionsCount_WhenValidRequestPassed_OkReceived()
    {
        // given
        var expectedList = new List<int>() { 1, 2, 3 };
        int transactionsCount = 5;
        int daysCount = 30;

        _mockLeadOverallStatisticsRepository.Setup(o => o.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, daysCount)).ReturnsAsync(expectedList);

        // when
        var actual = await _sut.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, daysCount);

        // then
        var actualResult = actual.Result as ObjectResult;
        var bundleResponse = actualResult.Value as List<int>;
        Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
        Assert.All(bundleResponse, x => expectedList.Contains(x));
        _mockLeadOverallStatisticsRepository.Verify(o => o.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, daysCount), Times.Once);
    }

    [Fact]
    public async Task GetLeadsIdsWithNecessaryAmountDifference_WhenValidRequestPassed_OkReceived()
    {
        // given
        var expectedList = new List<int>() { 1, 2, 3 };
        int daysCount = 30;
        decimal amountDifference = 12000;

        _mockLeadOverallStatisticsRepository.Setup(o => o.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, daysCount)).ReturnsAsync(expectedList);

        // when
        var actual = await _sut.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, daysCount);

        // then
        var actualResult = actual.Result as ObjectResult;
        var bundleResponse = actualResult.Value as List<int>;
        Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
        Assert.All(bundleResponse, x => expectedList.Contains(x));
        _mockLeadOverallStatisticsRepository.Verify(o => o.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, daysCount), Times.Once);
    }
}
