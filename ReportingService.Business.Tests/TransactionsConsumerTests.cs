using AutoMapper;
using IncredibleBackendContracts.Enums;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.Business.Consumers;
using ReportingService.Business.Models;
using ReportingService.Business.Services;

namespace ReportingService.Business.Tests;

public class TransactionsConsumerTests
{
    private TransactionCreatedEventConsumer _sutTransactionCreate;
    private TransferTransactionCreatedEventConsumer _sutTransferTransactionCreate;
    private Mock<ITransactionsService> _mockTrantsactionsService;
    private Mock<ILogger<TransactionCreatedEventConsumer>> _mockLoggerTransactionCreate;
    private Mock<ILogger<TransferTransactionCreatedEventConsumer>> _mockLoggerTransferTransactionCreate;
    private IMapper _mapper;

    public TransactionsConsumerTests()
    {
        _mockLoggerTransactionCreate = new Mock<ILogger<TransactionCreatedEventConsumer>>();
        _mockLoggerTransferTransactionCreate = new Mock<ILogger<TransferTransactionCreatedEventConsumer>>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _mockTrantsactionsService = new Mock<ITransactionsService>();
        _sutTransactionCreate = new TransactionCreatedEventConsumer(_mockLoggerTransactionCreate.Object, _mockTrantsactionsService.Object, _mapper);
        _sutTransferTransactionCreate = new TransferTransactionCreatedEventConsumer(_mockLoggerTransferTransactionCreate.Object, _mockTrantsactionsService.Object, _mapper);
    }

    [Fact]
    public async Task TransactionCreatedEventConsumer_WhenValidRequestPassed_TransactionAdded()
    {
        //given
        TransactionCreatedEvent transaction = new TransactionCreatedEvent
        {
            Id = 1,
            AccountId = 3,
            Date = DateTime.Now,
            TransactionType = TransactionType.Deposit,
            Amount = 100,
            Currency = Currency.USD,
            Rate = 61
        };

        var context = Mock.Of<ConsumeContext<TransactionCreatedEvent>>(c => c.Message == transaction);

        //when
        await _sutTransactionCreate.Consume(context);

        //then
        _mockTrantsactionsService.Verify(c => c.AddTransaction(It.Is<Transaction>(c =>
            c.Id == transaction.Id &&
            c.AccountId == transaction.AccountId &&
            c.Date == transaction.Date &&
            c.TransactionType == transaction.TransactionType &&
            c.Amount == transaction.Amount &&
            c.Currency == transaction.Currency &&
            c.Rate == transaction.Rate
        )), Times.Once);
    }

    [Fact]
    public async Task TransferTransactionCreatedEventConsumer_WhenValidRequestPassed_TransferAdded()
    {
        //given
        TransferTransactionCreatedEvent transaction = new TransferTransactionCreatedEvent
        {
            Id = 1,
            AccountId = 3,
            Date = DateTime.Now,
            TransactionType = TransactionType.Deposit,
            Amount = 100,
            Currency = Currency.USD,
            Rate = 61,
            RecipientId = 1,
            RecipientAccountId = 3,
            RecipientAmount = 6100,
            RecipientCurrency = Currency.RUB
        };

        var context = Mock.Of<ConsumeContext<TransferTransactionCreatedEvent>>(c => c.Message == transaction);

        //when
        await _sutTransferTransactionCreate.Consume(context);

        //then
        _mockTrantsactionsService.Verify(c => c.AddTransaction(It.Is<Transaction>(c =>
            c.Id == transaction.Id &&
            c.AccountId == transaction.AccountId &&
            c.Date == transaction.Date &&
            c.TransactionType == transaction.TransactionType &&
            c.Amount == transaction.Amount &&
            c.Currency == transaction.Currency &&
            c.Rate == transaction.Rate &&
            c.RecipientId == transaction.RecipientId &&
            c.RecipientAccountId == transaction.RecipientAccountId &&
            c.RecipientAmount == transaction.RecipientAmount && 
            c.RecipientCurrency == transaction.RecipientCurrency
        )), Times.Once);
    }
}
