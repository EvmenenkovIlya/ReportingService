using AutoMapper;
using IncredibleBackendContracts.Enums;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using NLog;
using ReportingService.Business.Consumers;
using ReportingService.Business.Models;
using ReportingService.Business.Services;

namespace ReportingService.Business.Tests;

public class LeadsConsumerTests
{
    private LeadsConsumer _sut;
    private Mock<ILeadInfoService> _mockleadInfoService;
    private Mock<ILogger<LeadsConsumer>> _mockLogger;
    private Mapper _mapper;


    public LeadsConsumerTests()
    {
        _mockLogger = new Mock<ILogger<LeadsConsumer>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _mockleadInfoService = new Mock<ILeadInfoService>();
        _sut = new LeadsConsumer(_mockLogger.Object, _mockleadInfoService.Object, _mapper);
    }

    [Fact]
    public async Task LeadCreatedEventConsumed_WhenValidRequestPassed_LeadInfoAdded()
    {
        //given
        LeadCreatedEvent leadCreatedEvent = new()
        {
            Id = 1,
            RegistrationDate = DateTime.Now,
            Birthday = DateTime.Now,
            FirstName = "Adam",
            LastName = "Smith",
            Patronymic = "Give me Patronymic later",
            Passport = "5555 555555",
            Phone = "+5553535",
            Address = "Pushkin Street, Kolotushkin building",
            City = City.Chelyabinsk,
            Email = "test@mail.com"
        };
        var context = Mock.Of<ConsumeContext<LeadCreatedEvent>>(c => c.Message == leadCreatedEvent);

        //when
        await _sut.Consume(context);

        //then
        _mockleadInfoService.Verify(c => c.AddLeadInfo(It.Is<LeadInfo>(c =>
            c.LeadId == leadCreatedEvent.Id &&
            c.RegistrationDate == leadCreatedEvent.RegistrationDate &&
            c.BirthDate == leadCreatedEvent.Birthday&&
            c.FirstName == leadCreatedEvent.FirstName &&
            c.LastName == leadCreatedEvent.LastName &&
            c.Patronymic == leadCreatedEvent.Patronymic &&
            c.Passport == leadCreatedEvent.Passport &&
            c.Phone == leadCreatedEvent.Phone &&
            c.Address == leadCreatedEvent.Address &&
            c.City == leadCreatedEvent.City &&
            c.Email == leadCreatedEvent.Email
        )), Times.Once);
    }

    [Fact]
    public async Task LeadUpdatedEventConsumed_WhenValidRequestPassed_LeadInfoUpdated()
    {
        //given
        LeadUpdatedEvent leadUpdatedEvent = new()
        {
            Id = 1,
            Birthday = DateTime.Now,
            FirstName = "Adam",
            LastName = "Smith",
            Patronymic = "Give me Patronymic later",
            Phone = "+5553535",
            Address = "Pushkin Street, Kolotushkin building",
            City = City.Chelyabinsk
        };
        var context = Mock.Of<ConsumeContext<LeadUpdatedEvent>>(c => c.Message == leadUpdatedEvent);

        //when
        await _sut.Consume(context);

        //then
        _mockleadInfoService.Verify(c => c.UpdateLeadInfo(It.Is<UpdateLeadInfo>(c =>
            c.LeadId == leadUpdatedEvent.Id &&
            c.BirthDate == leadUpdatedEvent.Birthday &&
            c.FirstName == leadUpdatedEvent.FirstName &&
            c.LastName == leadUpdatedEvent.LastName &&
            c.Patronymic == leadUpdatedEvent.Patronymic &&
            c.Phone == leadUpdatedEvent.Phone &&
            c.Address == leadUpdatedEvent.Address &&
            c.City == leadUpdatedEvent.City 
        )), Times.Once);
    }

    [Fact]
    public async Task LeadDeletedEventConsumed_WhenValidRequestPassed_LeadInfoDeleted()
    {
        //given
        LeadDeletedEvent leadDeletedEvent = new()
        {
            Id = 1
        };
        var context = Mock.Of<ConsumeContext<LeadDeletedEvent>>(c => c.Message == leadDeletedEvent);

        //when
        await _sut.Consume(context);

        //then
        _mockleadInfoService.Verify(c => c.DeleteLeadInfo(It.Is<int>(c =>
            c == leadDeletedEvent.Id)), Times.Once);
    }

    [Fact]
    public async Task LeadsRoleUpdateEventConsumed_WhenValidRequestPassed_LeadInfoDeleted()
    {
        //given
        LeadsRoleUpdatedEvent leadsRoleUpdatedEvent = new()
        {
            Ids = new List<int>() {1, 2, 3}
        };
        var context = Mock.Of<ConsumeContext<LeadsRoleUpdatedEvent>>(c => c.Message == leadsRoleUpdatedEvent);

        //when
        await _sut.Consume(context);

        //then
        _mockleadInfoService.Verify(c => c.UpdateLeadsStatus(It.Is<List<int>>(c =>
            c.Count == leadsRoleUpdatedEvent.Ids.Count)), Times.Once);
    }
}