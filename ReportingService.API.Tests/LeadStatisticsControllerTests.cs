using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.API.Controllers;
using ReportingService.Data.Repositories;

namespace ReportingService.API.Tests;

public class LeadStatisticsControllerTests
{
    private LeadStatisticsController _sut;
    private Mock<ILeadOverallStatisticsRepository> _mockLeadStatisticsRepository;
    private Mock<ILogger<LeadStatisticsController>> _logger;
    private IMapper _mapper;

    public LeadStatisticsControllerTests()
    {
        _mockLeadStatisticsRepository = new Mock<ILeadOverallStatisticsRepository>();
        _logger = new Mock<ILogger<LeadStatisticsController>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _sut = new LeadStatisticsController(_logger.Object, _mockLeadStatisticsRepository.Object);
    }

    [Fact]
    public async Task GetLeadIdsWithNecessaryTransactionsCount_WhenValidRequestPassed_OkReceived()
    {
        // given
        var expectedList = new List<int>() { 1, 2, 3 };
        int transactionsCount = 5;

        _mockLeadStatisticsRepository.Setup(o => o.GetLeadsIdsWith42Transactions()).ReturnsAsync(expectedList);

        // when
        var actual = await _sut.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount);

        // then
        var actualResult = actual.Result as ObjectResult;
        var bundleResponse = actualResult.Value as List<int>;
        Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
        Assert.All(bundleResponse, x => expectedList.Contains(x));
        _mockLeadStatisticsRepository.Verify(o => o.GetLeadsIdsWith42Transactions(), Times.Once);
    }

    [Fact]
    public async Task GetLeadsIdsWithNecessaryAmountDifference_WhenValidRequestPassed_OkReceived()
    {
        // given
        var expectedList = new List<int>() { 1, 2, 3 };

        _mockLeadStatisticsRepository.Setup(o => o.GetLeadsIdsWith42Transactions()).ReturnsAsync(expectedList);

        // when
        var actual = await _sut.GetLeadsIdsWithNecessaryAmountDifference();

        // then
        var actualResult = actual.Result as ObjectResult;
        var bundleResponse = actualResult.Value as List<int>;
        Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
        Assert.All(bundleResponse, x => expectedList.Contains(x));
        _mockLeadStatisticsRepository.Verify(o => o.GetLeadsIdsWith42Transactions(), Times.Once);
    }
}
