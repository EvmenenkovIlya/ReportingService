using AutoMapper;
using Microsoft.Extensions.Logging;
using ReportingService.Business.Models;
using ReportingService.Business.Services;
using ReportingService.Data.Dto;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Services;

public class TransactionsService : ITransactionsService
{
    private readonly ILogger<TransactionsService> _logger;
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IMapper _mapper;

    public TransactionsService(ILogger<TransactionsService> logger, ITransactionsRepository transactionsRepository, IMapper mapper)
    {
        _logger = logger;
        _transactionsRepository = transactionsRepository;
        _mapper = mapper;
    }

    public async Task AddTransaction(Transaction transaction)
    {
        var transactionDto = _mapper.Map<TransactionDto>(transaction);
        await _transactionsRepository.AddTransaction(transactionDto);
    }
}
