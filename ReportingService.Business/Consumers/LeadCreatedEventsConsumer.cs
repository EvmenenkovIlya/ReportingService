using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class LeadCreatedEventsConsumer : IConsumer<LeadCreatedEvent>
{
    private readonly ILogger<LeadCreatedEventsConsumer> _logger;
    private readonly ILeadInfoService _leadInfoService;
    private readonly IMapper _mapper;

    public LeadCreatedEventsConsumer(ILogger<LeadCreatedEventsConsumer> logger, ILeadInfoService leadInfoService, IMapper mapper)
    {
        _logger = logger;
        _leadInfoService = leadInfoService;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<LeadCreatedEvent> context)
    {
        var leadInfo = _mapper.Map<LeadInfo>(context.Message);
        _logger.LogInformation($"LeadCreatedEvent {leadInfo}");
        await _leadInfoService.AddLeadInfo(leadInfo);
    }
}
