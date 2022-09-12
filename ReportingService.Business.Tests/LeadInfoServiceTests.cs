using AutoMapper;
using IncredibleBackendContracts.Enums;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.Business.Exceptions;
using ReportingService.Business.Models;
using ReportingService.Business.Services;
using ReportingService.Data.Dto;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Tests;

public class LeadInfoServiceTests
{
    private readonly Mock<ILeadInfoRepository> _mockLeadInfoRepository;
    private readonly Mock<ILogger<LeadInfoService>> _mockLogger;
    private readonly IMapper _mapper;
    private readonly LeadInfoService _sut;

    public LeadInfoServiceTests()
    {
        _mockLeadInfoRepository = new Mock<ILeadInfoRepository>();
        _mockLogger = new Mock<ILogger<LeadInfoService>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _sut = new LeadInfoService(_mockLeadInfoRepository.Object, _mockLogger.Object, _mapper);
    }

    [Fact]
    public async Task GetCelebrantsFromDateToNow_WhenValidDate_ListReceived()
    {
        //given
        var date = 2;
        List<int> expectedResult = new List<int>() { 1, 2, 3 };
        var listDates = new List<DateTime>() { DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), DateTime.Now };
        _mockLeadInfoRepository.Setup(o => o.GetCelebrateIdsByDate(It.Is<DateTime>(x => x.Date == listDates[0].Date))).ReturnsAsync(new List<int>() { expectedResult[0] });
        _mockLeadInfoRepository.Setup(o => o.GetCelebrateIdsByDate(It.Is<DateTime>(x => x.Date == listDates[1].Date))).ReturnsAsync(new List<int>() { expectedResult[1] });
        _mockLeadInfoRepository.Setup(o => o.GetCelebrateIdsByDate(It.Is<DateTime>(x => x.Date == listDates[2].Date))).ReturnsAsync(new List<int>() { expectedResult[2] });

        //when
        var actual = await _sut.GetCelebrantsFromDateToNow(date);

        //then
        _mockLeadInfoRepository.Verify(o => o.GetCelebrateIdsByDate(It.Is<DateTime>(x => x.Date == DateTime.Now.Date)), Times.Once);
        Assert.All(actual, i => Assert.Contains(i, expectedResult));
    }

    [Fact]
    public async Task GetCelebrantsFromDateToNow_WhenInvalidDate_ThrowBadRequestException()
    {
        //given
        var daysCount = -1;
        //when

        //then
        await Assert.ThrowsAsync<BadRequestException>(() => _sut.GetCelebrantsFromDateToNow(daysCount));
    }

    [Fact]
    public async Task AddNewLead_WhenValidRequestPassed_LeadAdded()
    {
        //given
        LeadInfo newLead = new()
        {
            LeadId = 1,
            RegistrationDate = DateTime.Now,
            BirthDate = DateTime.Now,
            FirstName = "Adam",
            LastName = "Smith",
            Patronymic = "Give me Patronymic later",
            Passport = "5555 555555",
            Phone = "+5553535",
            Address = "Pushkin Street, Kolotushkin building",
            City = City.Chelyabinsk,
            Email = "test@mail.com"
        };

        //when
        await _sut.AddLeadInfo(newLead);

        //then
        _mockLeadInfoRepository.Verify(c => c.AddLeadInfo(It.Is<LeadInfoDto>(c =>
            c.LeadId == newLead.LeadId &&
            c.RegistrationDate == newLead.RegistrationDate &&
            c.BirthDate == newLead.BirthDate &&
            c.FirstName == newLead.FirstName &&
            c.LastName == newLead.LastName &&
            c.Patronymic == newLead.Patronymic &&
            c.Passport == newLead.Passport &&
            c.Phone == newLead.Phone &&
            c.Address == newLead.Address &&
            c.City == newLead.City &&
            c.Email == newLead.Email
        )), Times.Once);
    }

    [Fact]
    public async Task UpdateLead_WhenValidRequestPassed_LeadUpdated()
    {
        //given
        UpdateLeadInfo updatedLead = new()
        {
            LeadId = 1,
            BirthDate = DateTime.Now,
            FirstName = "Adam",
            LastName = "Smith",
            Patronymic = "Give me Patronymic later",
            Phone = "+5553535",
            Address = "Pushkin Street, Kolotushkin building",
            City = City.Chelyabinsk
        };

        //when
        await _sut.UpdateLeadInfo(updatedLead);

        //then
        _mockLeadInfoRepository.Verify(c => c.UpdateLeadInfo(It.Is<LeadInfoDto>(c =>
            c.LeadId == updatedLead.LeadId &&
            c.BirthDate == updatedLead.BirthDate &&
            c.FirstName == updatedLead.FirstName &&
            c.LastName == updatedLead.LastName &&
            c.Patronymic == updatedLead.Patronymic &&
            c.Phone == updatedLead.Phone &&
            c.Address == updatedLead.Address &&
            c.City == updatedLead.City)), Times.Once);
    }

    [Fact]
    public async Task DeleteLead_WhenValidRequestPassed_LeadDeleted()
    {
        //given
        var leadId = 1;

        //when
        await _sut.DeleteLeadInfo(leadId);

        //then
        _mockLeadInfoRepository.Verify(c => c.DeleteLeadInfo(leadId), Times.Once);
    }

    [Fact]
    public async Task GetAllLeadInfo_WhenValidRequestPassed_AllLeadInfoReturned()
    {
        //given
        var leadsDto = new List<LeadInfoDto>()
        {
            new()
            {
                Id = 1,
                LeadId = 1,
                FirstName = "Adam",
                LastName = "Smith",
                Patronymic = "Give me Patronymic later",
                BirthDate = DateTime.Now,
                RegistrationDate = DateTime.Now,
                Email = "test@email.com",
                Phone = "+5553535",
                Passport = "5555 555555",
                Address = "Pushkin Street, Kolotushkin building",
                City = City.Chelyabinsk,
                IsDeleted = true,
                Role = Role.Regular
            },
            new()
            {
                Id = 2,
                LeadId = 2,
                FirstName = "Smith",
                LastName = "Adam",
                Patronymic = "Give me Patronymic later",
                BirthDate = DateTime.Now.AddDays(-1),
                RegistrationDate = DateTime.Now.AddDays(-1),
                Email = "testfortest@email.com",
                Phone = "+666353545",
                Passport = "5555 666666",
                Address = "Kolotushkin building, Pushkin Street",
                City = City.Moscow,
                IsDeleted = false,
                Role = Role.Vip
            }
        };
        _mockLeadInfoRepository.Setup(o => o.GetAllLeadInfoDto()).ReturnsAsync(leadsDto);

        //when
        var result = await _sut.GetAllLeadInfo();

        //then
        _mockLeadInfoRepository.Verify(c => c.GetAllLeadInfoDto(), Times.Once);
        Assert.Multiple(() =>
        {
            Assert.Equal(leadsDto.Count, result.Count);
            Assert.Equal(leadsDto[0].LeadId, result[0].LeadId);
            Assert.Equal(leadsDto[0].Address, result[0].Address); 
            Assert.Equal(leadsDto[0].FirstName, result[0].FirstName);
            Assert.Equal(leadsDto[0].LastName, result[0].LastName);
            Assert.Equal(leadsDto[1].Patronymic, result[1].Patronymic);
            Assert.Equal(leadsDto[1].Passport, result[1].Passport);
            Assert.Equal(leadsDto[1].Phone, result[1].Phone);
            Assert.Equal(leadsDto[1].BirthDate, result[1].BirthDate);
            Assert.Equal(leadsDto[1].RegistrationDate, result[1].RegistrationDate);
        });
    }

    [Fact]
    public async Task GetLeadInfoByLeadId_WhenValidRequestPassed_LeadInfoReturned()
    {
        //given
        var leadId = 1;
        var leadsDto = new List<LeadInfoDto>()
        {
            new()
            {
                LeadId = 2,
            },
            new()
            {
                LeadId = 1
            }
        };
        var expectedLeadDto = leadsDto.Find(x => x.LeadId == leadId);
        _mockLeadInfoRepository.Setup(o => o.GetLeadInfoDtoByLeadId(leadId)).ReturnsAsync(expectedLeadDto);

        //when
        await _sut.GetLeadInfoByLeadId(leadId);

        //then
        _mockLeadInfoRepository.Verify(c => c.GetLeadInfoDtoByLeadId(leadId), Times.Once);
    }

    [Fact]
    public async Task UpdateLeadsStatus_WhenValidRequestPassed_LeadsInfoUpdated()
    {
        //given
        var vipIds = new List<int>() { 1, 2, 3 };

        //when
        await _sut.UpdateLeadsStatus(vipIds);

        //then

    }
}