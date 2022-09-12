using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class LeadDeletedEventsConsumer : IConsumer<LeadDeletedEvent>
{
    private readonly ILogger<LeadDeletedEventsConsumer> _logger;
    private readonly ILeadInfoService _leadInfoService;
    private readonly IMapper _mapper;

    public LeadDeletedEventsConsumer(ILogger<LeadDeletedEventsConsumer> logger, ILeadInfoService leadInfoService, IMapper mapper)
    {
        _logger = logger;
        _leadInfoService = leadInfoService;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<LeadDeletedEvent> context)
    {
        var leadId = context.Message.Id;
        _logger.LogInformation($"LeadDeletedEvent with LeadId = {leadId}");
        await _leadInfoService.DeleteLeadInfo(leadId);
    }
}
