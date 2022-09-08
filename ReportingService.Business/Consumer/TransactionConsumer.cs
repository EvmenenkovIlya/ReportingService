using IncredibleBackendContracts.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace T_Strore.Business.Consumers;

public class TransactionConsumer : IConsumer<CurrencyRate>
{

    private readonly ILogger<TransactionConsumer> _logger;

    public TransactionConsumer(ILogger<TransactionConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CurrencyRate> context)
    {
        var dictionaryConvert = new Dictionary<string, decimal>(context.Message.Rates);
        _logger.LogInformation($"RateConsumer: Save actual rates in model");
        //CurrencyRateModel.CurrencyRates = dictionaryConvert;
    }
}
