using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class TransferTransactionCreatedEventConsumer : IConsumer<TransferTransactionCreatedEvent>
{
    private readonly ILogger<TransferTransactionCreatedEventConsumer> _logger;
    private readonly ITransactionsService _transactionService;
    private readonly IMapper _mapper;

    public TransferTransactionCreatedEventConsumer(ILogger<TransferTransactionCreatedEventConsumer> logger, ITransactionsService transactionService, IMapper mapper)
    {
        _logger = logger;
        _transactionService = transactionService;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<TransferTransactionCreatedEvent> context)
    {
        var transfer = context.Message;
        _logger.LogInformation($"TransferTransactionCreatedEvent Id = {transfer.Id}, Amount = {transfer.Amount}, Currency = {transfer.Currency}, RecipientCurrency = {transfer.RecipientCurrency}, RecipientAmount  = {transfer.RecipientAmount}");
        await _transactionService.AddTransaction(_mapper.Map<Transaction>(transfer));
    }
}
