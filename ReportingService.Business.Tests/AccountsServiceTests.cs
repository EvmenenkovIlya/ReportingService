using AutoMapper;
using IncredibleBackendContracts.Enums;
using Microsoft.Extensions.Logging;
using Moq;
using ReportingService.Business.Models;
using ReportingService.Business.Services;
using ReportingService.Data.Dto;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Tests;

public class AccountsServiceTests
{
    private AccountsService _sut;
    private IMapper _mapper;
    private Mock<ILogger<AccountsService>> _mockLogger;
    private Mock<IAccountsRepository> _mockAccountsRepository;

    public AccountsServiceTests()
    {
        _mockLogger = new Mock<ILogger<AccountsService>>();
        _mockAccountsRepository = new Mock<IAccountsRepository>();
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<BusinessModelsMapperConfig>()));
        _sut = new AccountsService(_mockLogger.Object, _mockAccountsRepository.Object, _mapper);
    }

    [Fact]
    public async Task AddNewAccount_WhenValidModelPassed_AccountAdded()
    {
        //given
        Account account = new()
        {
            Currency = Currency.RUB,
            LeadId = 1,
            Id = 1,
            Status = AccountStatus.Active,
            AccountId = 1
            
        };

        //when
        await _sut.AddAccount(account);

        //then
        _mockAccountsRepository.Verify(c => c.AddAccount(It.Is<AccountDto>(c =>
            c.Id == account.Id &&
            c.AccountId == account.AccountId &&
            c.LeadId == account.LeadId &&
            c.Currency == account.Currency &&
            c.Status == account.Status
        )), Times.Once);
    }

    [Fact]
    public async Task UpdateAccount_WhenValidModelPassed_AccountUpdated()
    {
        //given
        var status = AccountStatus.Frozen;
        var accountId = 1;

        //when
        await _sut.UpdateAccount(accountId, status);

        //then
        _mockAccountsRepository.Verify(c => c.UpdateAccount(accountId, status), Times.Once);
    }

    [Fact]
    public async Task DeleteAccount_WhenValidRequestPassed_AccountDeleted()
    {
        //given
        var accountId = 1;

        //when
        await _sut.DeleteAccount(accountId);

        //then
        _mockAccountsRepository.Verify(c => c.DeleteAccount(accountId), Times.Once);
    }

    [Fact]
    public async Task GetAllAccounts_WhenValidRequestPassed_AllAccountsReturned()
    {
        //given
        List<AccountDto> accounts = new List<AccountDto>(){
            new() { Currency = Currency.RUB, LeadId = 1, Id = 1, Status = AccountStatus.Active, AccountId = 1},
            new() {Currency = Currency.USD, LeadId = 2, Id = 2, Status = AccountStatus.Frozen, AccountId = 2}
        };
        _mockAccountsRepository.Setup(o => o.GetAllAccounts()).ReturnsAsync(accounts);

        //when
        var result = await _sut.GetAllAccounts();

        //then
        Assert.Multiple(() =>
        {
            Assert.Equal(accounts.Count, result.Count);
            Assert.Equal(accounts[0].Currency, result[0].Currency);
            Assert.Equal(accounts[1].Currency, result[1].Currency);
        });
        _mockAccountsRepository.Verify(x => x.GetAllAccounts(), Times.Once);
    }

    [Fact]
    public async Task GetAccountById_WhenValidIdPassed_AccountReturned()
    {
        //given
        var accountId = 1;
        List<AccountDto> accounts = new List<AccountDto>(){
            new() { Currency = Currency.RUB, LeadId = 1, Id = 1, Status = AccountStatus.Active, AccountId = 1},
            new() { Currency = Currency.USD, LeadId = 2, Id = 2, Status = AccountStatus.Frozen, AccountId = 2}
        };
        var expectedAccountDto = accounts.Find(x => x.AccountId == accountId);

        _mockAccountsRepository.Setup(o => o.GetAccountById(accountId)).ReturnsAsync(expectedAccountDto);

        //when
        var result = await _sut.GetAccountById(accountId);

        //then
        Assert.Multiple(() =>
        {
            Assert.Equal(expectedAccountDto.Currency, result.Currency);
            Assert.Equal(expectedAccountDto.LeadId, result.LeadId);
            Assert.Equal(expectedAccountDto.Id, result.Id);
            Assert.Equal(expectedAccountDto.Status, result.Status);
            Assert.Equal(expectedAccountDto.AccountId, result.AccountId);
        });
        _mockAccountsRepository.Verify(x => x.GetAccountById(accountId), Times.Once);
    }
}
