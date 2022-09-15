using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class TransactionCreatedEventConsumer : IConsumer<TransactionCreatedEvent>

{
    private readonly ILogger<TransactionCreatedEventConsumer> _logger;
    private readonly ITransactionsService _transactionService;
    private readonly IMapper _mapper;

    public TransactionCreatedEventConsumer(ILogger<TransactionCreatedEventConsumer> logger, ITransactionsService transactionService, IMapper mapper)
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
