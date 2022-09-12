using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Business.Services;

namespace ReportingService.Business.Consumers;

public class AccountCreatedEventConsumer: IConsumer<AccountCreatedEvent>
{
    private readonly ILogger<AccountCreatedEventConsumer> _logger;
    private readonly IMapper _mapper;
    private readonly IAccountsService _accountsService;

    public AccountCreatedEventConsumer(ILogger<AccountCreatedEventConsumer> logger, IMapper mapper, IAccountsService accountsService)
    {
        _logger = logger;
        _mapper = mapper;
        _accountsService = accountsService;
    }

    public async Task Consume(ConsumeContext<AccountCreatedEvent> context)
    {
        var account = context.Message;
        _logger.LogInformation($"AccountCreatedEvent Id = {account.Id}, LeadId = {account.LeadId}, Currency = {account.Currency}, Status = {account.Status}");
        await _accountsService.AddAccount(_mapper.Map<Account>(account));
    }
}
