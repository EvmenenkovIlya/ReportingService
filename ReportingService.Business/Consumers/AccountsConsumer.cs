using AutoMapper;
using IncredibleBackendContracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Business.Services;
using T_Strore.Business.Consumers;

namespace ReportingService.Business.Consumers;

public class AccountsConsumer: IConsumer<AccountCreatedEvent>, IConsumer<AccountUpdatedEvent>, IConsumer<AccountDeletedEvent>
{
    private readonly ILogger<AccountsConsumer> _logger;
    private readonly IMapper _mapper;
    private readonly IAccountsService _accountsService;

    public AccountsConsumer(ILogger<AccountsConsumer> logger, IMapper mapper, IAccountsService accountsService)
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

    public async Task Consume(ConsumeContext<AccountUpdatedEvent> context)
    {
        var accountId = context.Message.Id;
        var status = context.Message.Status;
        _logger.LogInformation($"AccountUpdateEvent accountId = {accountId}, status = {status}");
        await _accountsService.UpdateAccount(accountId, status);
    }

    public async Task Consume(ConsumeContext<AccountDeletedEvent> context)
    {
        _logger.LogInformation($"AccountDeleteEvent context.Message.Id = {context.Message.Id}");
        await _accountsService.DeleteAccount(context.Message.Id);
    }
}
