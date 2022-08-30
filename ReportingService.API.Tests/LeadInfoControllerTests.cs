using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.API.Controllers;
using ReportingService.Business.Services;

namespace ReportingService.API.Tests;

public class LeadInfoControllerTests
{
    private LeadInfoController _sut;
    private Mock<ILeadInfoService> _mockLeadInfoService;
    private Mock<ILogger<LeadInfoController>> _logger;
    private IMapper _mapper;

    public LeadInfoControllerTests()
    {
        _mockLeadInfoService = new Mock<ILeadInfoService>();
        _logger = new Mock<ILogger<LeadInfoController>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _sut = new LeadInfoController(_logger.Object, _mockLeadInfoService.Object);
    }

    [Fact]
    public async Task GetCelebrantsFromDateToNow_WhenValidRequestPassed_OkReceived()
    {
        // given
        var expectedList = new List<int>() { 1, 2, 3 };
        var date = DateTime.Now;
        _mockLeadInfoService.Setup(o => o.GetCelebrantsFromDateToNow(date)).ReturnsAsync(expectedList);

        // when
        var actual = await _sut.GetCelebrantsFromDateToNow(date);

        // then
        var actualResult = actual.Result as ObjectResult;
        var listResponse = actualResult.Value as List<int>;
        Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
        Assert.All(listResponse, i => Assert.Contains(i, expectedList));
        _mockLeadInfoService.Verify(o => o.GetCelebrantsFromDateToNow(date), Times.Once);
    }
}