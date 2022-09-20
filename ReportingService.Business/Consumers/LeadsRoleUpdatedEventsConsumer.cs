using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class LeadsRoleUpdatedEventsConsumer : IConsumer<LeadsRoleUpdatedEvent>
{
    private readonly ILogger<LeadsRoleUpdatedEventsConsumer> _logger;
    private readonly ILeadInfoService _leadInfoService;

    public LeadsRoleUpdatedEventsConsumer(ILogger<LeadsRoleUpdatedEventsConsumer> logger, ILeadInfoService leadInfoService)
    {
        _logger = logger;
        _leadInfoService = leadInfoService;
    }

    public async Task Consume(ConsumeContext<LeadsRoleUpdatedEvent> context)
    {
        var vipIds = context.Message.Ids;
        _logger.LogInformation($"LeadsRoleUpdatedEvent with count of vips = {vipIds.Count}");
        await _leadInfoService.UpdateLeadsStatus(vipIds);
    }
}
