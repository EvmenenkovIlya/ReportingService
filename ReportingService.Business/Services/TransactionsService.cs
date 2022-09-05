using Microsoft.Extensions.Logging;

namespace ReportingService.Business.Services;

public class TransactionsService
{
    private readonly ILogger<TransactionsService> _logger;

    public TransactionsService(ILogger<TransactionsService> logger)
    {
        _logger = logger;
    }
}
