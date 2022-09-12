using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class AccountUpdatedEventsConsumer : IConsumer<AccountUpdatedEvent>
{
    private readonly ILogger<AccountUpdatedEventsConsumer> _logger;
    private readonly IMapper _mapper;
    private readonly IAccountsService _accountsService;

    public AccountUpdatedEventsConsumer(ILogger<AccountUpdatedEventsConsumer> logger, IMapper mapper, IAccountsService accountsService)
    {
        _logger = logger;
        _mapper = mapper;
        _accountsService = accountsService;
    }

    public async Task Consume(ConsumeContext<AccountUpdatedEvent> context)
    {
        var accountId = context.Message.Id;
        var status = context.Message.Status;
        _logger.LogInformation($"AccountUpdateEvent accountId = {accountId}, status = {status}");
        await _accountsService.UpdateAccount(accountId, status);
    }
}
