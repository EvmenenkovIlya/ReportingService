using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.API.Controllers;
using ReportingService.Data.Repositories;

namespace ReportingService.API.Tests
{
    public class LeadInformationsControllerTests
    {
        private LeadInformationsController _sut;
        private Mock<ILeadInformationsRepository> _mockLeadInformationsRepository;
        private Mock<ILogger<LeadInformationsController>> _logger;
        private IMapper _mapper;


        public LeadInformationsControllerTests()
        {
            _mockLeadInformationsRepository = new Mock<ILeadInformationsRepository>();
            _logger = new Mock<ILogger<LeadInformationsController>>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperConfigStorageAPI>()));
            _sut = new LeadInformationsController(_logger.Object, _mockLeadInformationsRepository.Object);
        }

        [Fact]
        public async Task GetLeadsIdsWithBirthday_WhenValidRequestPassed_OkReceived()
        {
            // given
            var expectedList = new List<int>() { 1, 2, 3 };

            _mockLeadInformationsRepository.Setup(o => o.GetAllBirthdayIds()).ReturnsAsync(expectedList);

            // when
            var actual = await _sut.GetLeadsIdsWithBirthday();

            // then
            var actualResult = actual.Result as ObjectResult;
            var bundleResponse = actualResult.Value as List<int>;
            Assert.Equal(StatusCodes.Status200OK, actualResult.StatusCode);
            Assert.All(bundleResponse, x => expectedList.Contains(x) );
            _mockLeadInformationsRepository.Verify(o => o.GetAllBirthdayIds(), Times.Once);
        }
    }
}