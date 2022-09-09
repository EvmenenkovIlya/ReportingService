
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;

namespace T_Strore.Business.Consumers;

public class TransactionCunsumer : IConsumer<TransactionTStoreModel>
{

    private readonly ILogger<TransactionCunsumer> _logger;

    public TransactionCunsumer(ILogger<TransactionCunsumer> logger)
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
