using Moq;
using ReportingService.Business.Services;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Tests
{
    public class LeadInfoServiceTests
    {
        private readonly LeadInfoService _sut;
        private readonly Mock<ILeadInfoRepository> _mockLeadInfoRepository;

        public LeadInfoServiceTests()
        {
            _mockLeadInfoRepository = new Mock<ILeadInfoRepository>();
            _sut = new LeadInfoService(_mockLeadInfoRepository.Object);
        }

        [Fact]
        public async Task GetCelebrantsFromDateToNow_WhenValidDate_ListReceived()
        {
            //given
            var date = DateTime.Now;
            List<int> expectedResult = new List<int>() { 1, 2, 3 };
            _mockLeadInfoRepository.Setup(o => o.GetCelebrateIdsByDate(date)).ReturnsAsync(expectedResult);

            //when
            var actual = await _sut.GetCelebrantsFromDateToNow(date);

            //then
            _mockLeadInfoRepository.Verify(o => o.GetCelebrateIdsByDate(date), Times.Once);
            Assert.All(actual, i => Assert.Contains(i, expectedResult));
        }
    }
}