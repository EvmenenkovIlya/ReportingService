<<<<<<< HEAD:ReportingService.Business/Cunsumer/TransactionCunsumer.cs
﻿
=======
﻿using IncredibleBackendContracts.ExchangeModels;
>>>>>>> REP-9:ReportingService.Business/Consumer/TransactionConsumer.cs
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;

namespace T_Strore.Business.Consumers;

<<<<<<< HEAD:ReportingService.Business/Cunsumer/TransactionCunsumer.cs
public class TransactionCunsumer : IConsumer<TransactionTStoreModel>
=======
public class TransactionConsumer : IConsumer<CurrencyRate>
>>>>>>> REP-9:ReportingService.Business/Consumer/TransactionConsumer.cs
{

    private readonly ILogger<TransactionConsumer> _logger;

    public TransactionConsumer(ILogger<TransactionConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<TransactionTStoreModel> context)
    {
<<<<<<< HEAD:ReportingService.Business/Cunsumer/TransactionCunsumer.cs
        var transactionConvert = new TransactionTStoreModel()
        {
            Amount = context.Message.Amount,
            Date = context.Message.Date,
            AccountId = context.Message.AccountId,
            TransactionType = context.Message.TransactionType,
            Currency = context.Message.Currency
        };

=======
        var dictionaryConvert = new Dictionary<string, decimal>(context.Message.Rates);
        _logger.LogInformation($"RateConsumer: Save actual rates in model");
        //CurrencyRateModel.CurrencyRates = dictionaryConvert;
>>>>>>> REP-9:ReportingService.Business/Consumer/TransactionConsumer.cs
    }
}
