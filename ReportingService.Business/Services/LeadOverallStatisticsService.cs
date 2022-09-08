using Microsoft.Extensions.Logging;
using ReportingService.Business.Exceptions;
using ReportingService.Data.Dto;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Services;

public class LeadOverallStatisticsService : ILeadOverallStatisticsService
{
    private readonly ILeadOverallStatisticsRepository _leadOverallStatisticRepository;
    private readonly ILogger<LeadOverallStatisticsService> _logger;

    public LeadOverallStatisticsService(ILeadOverallStatisticsRepository leadOverallStatisticRepository, ILogger<LeadOverallStatisticsService> logger)
    {
        _leadOverallStatisticRepository = leadOverallStatisticRepository;
        _logger = logger;
    }

    public async Task Execute()
    {
        await CreateLeadsOverallStatistics();
    }

    public async Task CreateLeadsOverallStatistics()
    {
        var result = await _leadOverallStatisticRepository.GetLeadOverallStatisticsDto(DateTime.Now);
    }

    public Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, int daysCount)
    {
        var date = GetDateFromDaysCount(daysCount);
        ValidateDate(date);

        _logger.LogInformation($"Business layer: Request in data base for get users users who have made transactions greater than {transactionsCount}");
        var result = _leadOverallStatisticRepository.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, date);

        _logger.LogInformation("Business layer: Returns users ids to Controller");
        return result;
    }

    public Task<List<int>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, int daysCount)
    {
        var date = GetDateFromDaysCount(daysCount);
        ValidateDate(date);

        _logger.LogInformation($"Business layer: Request in data base for get users whose difference between deposits and withdrawals is {amountDifference}");
        var result = _leadOverallStatisticRepository.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, date);

        _logger.LogInformation("Business layer: Returns users ids to Controller");
        return result;
    }

    private DateTime GetDateFromDaysCount(int daysCount) => DateTime.Now.AddDays(-daysCount);

    private void ValidateDate(DateTime fromDate)
    {
        var today = DateTime.Now.Date;

        if (fromDate.Date > today || (today - fromDate.Date).TotalDays > 366)
        {
            throw new BadRequestException("Date must be less or equal than today");
        }
    }
}