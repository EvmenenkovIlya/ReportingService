using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class AccountDeletedEventsConsumer: IConsumer<AccountDeletedEvent>
{
    private readonly ILogger<AccountDeletedEventsConsumer> _logger;
    private readonly IMapper _mapper;
    private readonly IAccountsService _accountsService;

    public AccountDeletedEventsConsumer(ILogger<AccountDeletedEventsConsumer> logger, IMapper mapper, IAccountsService accountsService)
    {
        _logger = logger;
        _mapper = mapper;
        _accountsService = accountsService;
    }


    public async Task Consume(ConsumeContext<AccountDeletedEvent> context)
    {
        _logger.LogInformation($"AccountDeleteEvent context.Message.Id = {context.Message.Id}");
        await _accountsService.DeleteAccount(context.Message.Id);
    }
}
