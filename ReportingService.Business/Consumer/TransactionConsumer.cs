
﻿using IncredibleBackendContracts.ExchangeModels;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;

namespace T_Strore.Business.Consumers;

public class TransactionConsumer : IConsumer<TransactionTStoreModel>

{
    private readonly ILogger<TransactionConsumer> _logger;

    public TransactionConsumer(ILogger<TransactionConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<TransactionTStoreModel> context)
    {
        var transactionConvert = new TransactionTStoreModel()
        {
            Amount = context.Message.Amount,
            Date = context.Message.Date,
            AccountId = context.Message.AccountId,
            TransactionType = context.Message.TransactionType,
            Currency = context.Message.Currency
        };

    }
}
