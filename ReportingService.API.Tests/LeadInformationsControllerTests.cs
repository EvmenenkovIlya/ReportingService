using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.API.Controllers;
using ReportingService.Data.Repositories;

namespace ReportingService.API.Tests;

public class LeadInformationsControllerTests
{
    private LeadInfoController _sut;
    private Mock<ILeadInfoRepository> _mockLeadInformationsRepository;
    private Mock<ILogger<LeadInfoController>> _logger;
    private IMapper _mapper;

    public LeadInformationsControllerTests()
    {
        _mockLeadInformationsRepository = new Mock<ILeadInfoRepository>();
        _logger = new Mock<ILogger<LeadInfoController>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _sut = new LeadInfoController(_logger.Object, _mockLeadInformationsRepository.Object);
    }

    [Fact]
    public async Task GetLeadsIdsWithBirthday_WhenValidRequestPassed_OkReceived()
    {
        // given
        var expectedList = new List<int>() { 1, 2, 3 };
        var date = DateTime.Now;
        _mockLeadInformationsRepository.Setup(o => o.GetCelebrateIdsByDate(It.IsAny<DateTime>())).ReturnsAsync(expectedList);

        // when
        var actual = await _sut.GetCelebrantsFromDateToNow(new DateTime());

        // then
        var actualResult = actual.Result as ObjectResult;
        var bundleResponse = actualResult.Value as List<int>;
        Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
        Assert.All(bundleResponse, x => expectedList.Contains(x));
        _mockLeadInformationsRepository.Verify(o => o.GetCelebrateIdsByDate(It.IsAny<DateTime>()), Times.Once);
    }
}