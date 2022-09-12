using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Business.Services.Interfaces;

namespace ReportingService.Business.Consumers;

public class TransactionConsumer : IConsumer<TransactionCreatedEvent>

{
    private readonly ILogger<TransactionConsumer> _logger;
    private readonly ITransactionsService _transactionService;
    private readonly IMapper _mapper;

    public TransactionConsumer(ILogger<TransactionConsumer> logger, ITransactionsService transactionService, IMapper mapper)
    {
        _logger = logger;
        _transactionService = transactionService;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<TransactionCreatedEvent> context)
    {
        var transaction = context.Message;
        _logger.LogInformation($"TransactionCreatedEvent Id = {transaction.Id}, Amount = {transaction.Amount}, Currency = {transaction.Currency}");
        await _transactionService.AddTransaction(_mapper.Map<Transaction>(transaction));
    }
}
