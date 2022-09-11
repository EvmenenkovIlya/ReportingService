using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace ReportingService.Business.Consumers;

public class LeadConsumer : IConsumer<LeadCreatedEvent>
{
    private readonly ILogger<LeadConsumer> _logger;

    public LeadConsumer(ILogger<LeadConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<LeadCreatedEvent> context)
    {

    }
}
