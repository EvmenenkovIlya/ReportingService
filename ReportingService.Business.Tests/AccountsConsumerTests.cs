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

public class AccountsConsumerTests
{
    private AccountDeletedEventsConsumer _sutDelete;
    private AccountUpdatedEventsConsumer _sutUpdate;
    private AccountCreatedEventConsumer _sutCreate;
    private Mock<IAccountsService> _mockAccountsService;
    private Mock<ILogger<AccountDeletedEventsConsumer>> _mockLoggerDelete;
    private Mock<ILogger<AccountUpdatedEventsConsumer>> _mockLoggerUpdate;
    private Mock<ILogger<AccountCreatedEventConsumer>> _mockLoggerCreate;
    private Mapper _mapper;


    public AccountsConsumerTests()
    {
        _mockLoggerDelete = new Mock<ILogger<AccountDeletedEventsConsumer>>();
        _mockLoggerUpdate = new Mock<ILogger<AccountUpdatedEventsConsumer>>();
        _mockLoggerCreate = new Mock<ILogger<AccountCreatedEventConsumer>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _mockAccountsService = new Mock<IAccountsService>();
        _sutDelete = new AccountDeletedEventsConsumer(_mockLoggerDelete.Object, _mapper, _mockAccountsService.Object);
        _sutUpdate = new AccountUpdatedEventsConsumer(_mockLoggerUpdate.Object, _mapper, _mockAccountsService.Object);
        _sutCreate = new AccountCreatedEventConsumer(_mockLoggerCreate.Object, _mapper, _mockAccountsService.Object);
    }

    [Fact]
    public async Task AccountCreatedEventConsumed_WhenValidRequestPassed_AccountAdded()
    {
        //given
        AccountCreatedEvent createdAccount = new()
        {
            Id = 1,
            Currency = Currency.USD,
            LeadId = 1,
            Status = AccountStatus.Active
        };
        var context = Mock.Of<ConsumeContext<AccountCreatedEvent>>(c => c.Message == createdAccount);

        //when
        await _sutCreate.Consume(context);

        //then
        _mockAccountsService.Verify(c => c.AddAccount(It.Is<Account>(c =>
            c.AccountId == createdAccount.Id &&
            c.LeadId == createdAccount.LeadId &&
            c.Currency == createdAccount.Currency &&
            c.Status == createdAccount.Status
        )), Times.Once);
    }

    [Fact]
    public async Task AccountUpdatedEventConsumed_WhenValidRequestPassed_AccountUpdated()
    {
        //given
        AccountUpdatedEvent updatedAccount = new()
        {
            Id = 1,
            Status = AccountStatus.Active
        };
        var context = Mock.Of<ConsumeContext<AccountUpdatedEvent>>(c => c.Message == updatedAccount);

        //when
        await _sutUpdate.Consume(context);

        //then
        _mockAccountsService.Verify(c => c.UpdateAccount(It.Is<int>(c =>
            c == updatedAccount.Id), It.Is<AccountStatus>(c => c == updatedAccount.Status)), Times.Once);
    }

    [Fact]
    public async Task AccountDeletedEventConsumed_WhenValidRequestPassed_AccountDeleted()
    {
        //given
        AccountDeletedEvent deletedAccount = new()
        {
            Id = 1
        };
        var context = Mock.Of<ConsumeContext<AccountDeletedEvent>>(c => c.Message == deletedAccount);

        //when
        await _sutDelete.Consume(context);

        //then
        _mockAccountsService.Verify(c => c.DeleteAccount(It.Is<int>(c =>
            c == deletedAccount.Id)), Times.Once);
    }
}
