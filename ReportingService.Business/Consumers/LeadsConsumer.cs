using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class LeadsConsumer : IConsumer<LeadCreatedEvent>, IConsumer<LeadUpdatedEvent>, IConsumer<LeadDeletedEvent>, IConsumer<LeadsRoleUpdatedEvent>
{
    private readonly ILogger<LeadsConsumer> _logger;
    private readonly ILeadInfoService _leadInfoService;
    private readonly IMapper _mapper;

    public LeadsConsumer(ILogger<LeadsConsumer> logger, ILeadInfoService leadInfoService, IMapper mapper)
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

    public async Task Consume(ConsumeContext<LeadUpdatedEvent> context)
    {
        var updatedLeadInfo = _mapper.Map<UpdateLeadInfo>(context.Message);
        _logger.LogInformation($"LeadUpdatedEvent {updatedLeadInfo}");
        await _leadInfoService.UpdateLeadInfo(updatedLeadInfo);
    }

    public async Task Consume(ConsumeContext<LeadDeletedEvent> context)
    {
        int leadId = context.Message.Id;
        _logger.LogInformation($"LeadDeletedEvent with LeadId = {leadId}");
        await _leadInfoService.DeleteLeadInfo(leadId);
    }

    public async Task Consume(ConsumeContext<LeadsRoleUpdatedEvent> context)
    {
        List<int> vipIds = context.Message.Ids;
        _logger.LogInformation($"LeadsRoleUpdatedEvent with count of vips = {vipIds.Count}");
        await _leadInfoService.UpdateLeadsStatus(vipIds);
    }
}
