using Microsoft.Extensions.Logging;
using Moq;
using NLog;
using ReportingService.Business.Exceptions;
using ReportingService.Business.Services;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Tests
{
    public class LeadInfoServiceTests
    {
        private readonly Mock<ILeadInfoRepository> _mockLeadInfoRepository;
        private readonly Mock<ILogger<LeadInfoService>> _mockLogger;
        private readonly LeadInfoService _sut;

        public LeadInfoServiceTests()
        {
            _mockLeadInfoRepository = new Mock<ILeadInfoRepository>();
            _mockLogger = new Mock<ILogger<LeadInfoService>>();
            _sut = new LeadInfoService(_mockLeadInfoRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetCelebrantsFromDateToNow_WhenValidDate_ListReceived()
        {
            //given
            var date = DateTime.Now;
            List<int> expectedResult = new List<int>() { 1, 2, 3 };
            var listDates = new List<DateTime>() { DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), DateTime.Now };
            _mockLeadInfoRepository.Setup(o => o.GetCelebrateIdsByDate(It.Is<DateTime>(x => x.Date == listDates[0].Date))).ReturnsAsync(new List<int>() { expectedResult[0] });
            _mockLeadInfoRepository.Setup(o => o.GetCelebrateIdsByDate(It.Is<DateTime>(x => x.Date == listDates[1].Date))).ReturnsAsync(new List<int>() { expectedResult[1] });
            _mockLeadInfoRepository.Setup(o => o.GetCelebrateIdsByDate(It.Is<DateTime>(x => x.Date == listDates[2].Date))).ReturnsAsync(new List<int>() { expectedResult[2] });

            //when
            var actual = await _sut.GetCelebrantsFromDateToNow(date);

            //then
            _mockLeadInfoRepository.Verify(o => o.GetCelebrateIdsByDate(date), Times.Once);
            Assert.All(actual, i => Assert.Contains(i, expectedResult));
        }

        [Fact]
        public async Task GetCelebrantsFromDateToNow_WhenInvalidDate_ThrowBadRequestException()
        {
            //given
            var date = DateTime.Now.AddDays(1);
            //when

            //then
            await Assert.ThrowsAsync<BadRequestException>(() => _sut.GetCelebrantsFromDateToNow(date));
        }
    }
}