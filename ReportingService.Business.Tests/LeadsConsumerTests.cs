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
    private LeadCreatedEventsConsumer _sutCreate;
    private LeadUpdatedEventsConsumer _sutUpdated;
    private LeadDeletedEventsConsumer _sutDeleted;
    private LeadsRoleUpdatedEventsConsumer _sutRoles;
    private Mock<ILeadInfoService> _mockleadInfoService;
    private Mock<ILogger<LeadCreatedEventsConsumer>> _mockLoggerCreate;
    private Mock<ILogger<LeadUpdatedEventsConsumer>> _mockLoggerUpdate;
    private Mock<ILogger<LeadDeletedEventsConsumer>> _mockLoggerDelete;
    private Mock<ILogger<LeadsRoleUpdatedEventsConsumer>> _mockLoggerRoles;
    private Mapper _mapper;


    public LeadsConsumerTests()
    {
        _mockLoggerCreate = new Mock<ILogger<LeadCreatedEventsConsumer>>();
        _mockLoggerUpdate = new Mock<ILogger<LeadUpdatedEventsConsumer>>();
        _mockLoggerDelete = new Mock<ILogger<LeadDeletedEventsConsumer>>();
        _mockLoggerRoles = new Mock<ILogger<LeadsRoleUpdatedEventsConsumer>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _mockleadInfoService = new Mock<ILeadInfoService>();
        _sutCreate = new LeadCreatedEventsConsumer(_mockLoggerCreate.Object, _mockleadInfoService.Object, _mapper);
        _sutUpdated = new LeadUpdatedEventsConsumer(_mockLoggerUpdate.Object, _mockleadInfoService.Object, _mapper);
        _sutDeleted = new LeadDeletedEventsConsumer(_mockLoggerDelete.Object, _mockleadInfoService.Object, _mapper);
        _sutRoles = new LeadsRoleUpdatedEventsConsumer(_mockLoggerRoles.Object, _mockleadInfoService.Object, _mapper);
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
        await _sutCreate.Consume(context);

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
        await _sutUpdated.Consume(context);

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
        await _sutDeleted.Consume(context);

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
        await _sutRoles.Consume(context);

        //then
        _mockleadInfoService.Verify(c => c.UpdateLeadsStatus(It.Is<List<int>>(c =>
            c.Count == leadsRoleUpdatedEvent.Ids.Count)), Times.Once);
    }
}