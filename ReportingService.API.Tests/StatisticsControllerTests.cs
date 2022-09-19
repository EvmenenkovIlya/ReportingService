using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.API.Controllers;
using ReportingService.Business.Models;
using ReportingService.Business.Services;

namespace ReportingService.API.Tests;

public class StatisticsControllerTests
{
    private StatisticsController _sut;
    private Mock<IStatisticsService> _mockStatisticsService;
    private Mock<ILogger<StatisticsController>> _logger;
    private IMapper _mapper;

    public StatisticsControllerTests()
    {
        _mockStatisticsService = new Mock<IStatisticsService>();
        _logger = new Mock<ILogger<StatisticsController>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<APIModelsMapperConfig>()));
        _sut = new StatisticsController(_logger.Object, _mockStatisticsService.Object, _mapper);
    }

    [Fact]
    public async Task GetStatisticsByDates_WhenValidRequestPassed_OkReceived()
    {
        // given
        var yesterday = DateTime.Today.AddDays(-1);
        var today = DateTime.Today;
        var expectedList = new List<Statistics>() { new(){DateStatistic = yesterday }, new (){DateStatistic = today} };

        _mockStatisticsService.Setup(o => o.GetStatisticsByPeriod(yesterday, today)).ReturnsAsync(expectedList);

        // when
        var actual = await _sut.GetStatisticsByDates(yesterday, today);

        // then
        var actualResult = actual.Result as ObjectResult;
        var bundleResponse = actualResult.Value as List<Statistics>;
        Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
        _mockStatisticsService.Verify(o => o.GetStatisticsByPeriod(yesterday, today), Times.Once);
    }
}

