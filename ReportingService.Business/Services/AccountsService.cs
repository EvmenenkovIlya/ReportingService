using AutoMapper;
using IncredibleBackendContracts.Enums;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Data.Dto;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Services;

public class AccountsService : IAccountsService
{
    private readonly ILogger<AccountsService> _logger;
    private readonly IAccountsRepository _accountsRepository;
    private readonly IMapper _mapper;

    public AccountsService(ILogger<AccountsService> logger, IAccountsRepository accountsRepository, IMapper mapper)
    {
        _logger = logger;
        _accountsRepository = accountsRepository;
        _mapper = mapper;
    }

    public async Task AddAccount(Account account)
    {
        _logger.LogInformation($"Create new account {account}");
        await _accountsRepository.AddAccount(_mapper.Map<AccountDto>(account));
    }

    public async Task<List<Account>> GetAllAccounts()
    {
        _logger.LogInformation("Try to get all accounts");
        var result = await _accountsRepository.GetAllAccounts();
        return _mapper.Map<List<Account>>(result);
    }

    public async Task<Account> GetAccountById(int accountId)
    {
        _logger.LogInformation($"Get account with accountId = {accountId}");
        var result = await _accountsRepository.GetAccountById(accountId);
        return _mapper.Map<Account>(result);
    }

    public async Task DeleteAccount(int accountId)
    {
        _logger.LogInformation($"Delete account with accountId = {accountId}");
        await _accountsRepository.DeleteAccount(accountId);
    }


    public async Task UpdateAccount(int accountId, AccountStatus status)
    {
        _logger.LogInformation($"Update account's Status with accountId {accountId} to Status = {status}");
        await _accountsRepository.UpdateAccount(accountId, status);
    }
}
