
using AutoMapper;
using IncredibleBackendContracts.Enums;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.Business.Models;
using ReportingService.Business.Services;
using ReportingService.Data.Dto;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Tests;

public class TransactionsServiceTests
{
    private readonly Mock<ILogger<TransactionsService>> _mockLogger;
    private readonly Mock<ITransactionsRepository> _mockTransactionsRepository;
    private readonly IMapper _mapper;
    private readonly TransactionsService _sut;

    public TransactionsServiceTests()
    {
        _mockLogger = new Mock<ILogger<TransactionsService>>();
        _mockTransactionsRepository = new Mock<ITransactionsRepository>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _sut = new TransactionsService(_mockLogger.Object, _mockTransactionsRepository.Object, _mapper);
    }

    [Fact]
    public async Task AddTransaction_WhenCall_ExecuteRepositoryMethod()
    {
        //given
        var transaction = new Transaction
        {
            TransactionId = 1,
            AccountId = 1,
            Date = DateTime.Now,
            TransactionType = TransactionType.Withdraw,
            Amount = 100,
            Currency = Currency.CSK,
            Rate = 20
        };

        //when
        await _sut.AddTransaction(transaction);

        //then

        _mockTransactionsRepository.Verify(o => o.AddTransaction(It.Is<TransactionDto>(x => x.TransactionId == transaction.TransactionId)), Times.Once);
    }
}
