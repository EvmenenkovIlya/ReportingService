using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class LeadUpdatedEventsConsumer : IConsumer<LeadUpdatedEvent>
{
    private readonly ILogger<LeadUpdatedEventsConsumer> _logger;
    private readonly ILeadInfoService _leadInfoService;
    private readonly IMapper _mapper;

    public LeadUpdatedEventsConsumer(ILogger<LeadUpdatedEventsConsumer> logger, ILeadInfoService leadInfoService, IMapper mapper)
    {
        _logger = logger;
        _leadInfoService = leadInfoService;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<LeadUpdatedEvent> context)
    {
        var updatedLeadInfo = _mapper.Map<UpdateLeadInfo>(context.Message);
        _logger.LogInformation($"LeadUpdatedEvent {updatedLeadInfo}");
        await _leadInfoService.UpdateLeadInfo(updatedLeadInfo);
    }
}
