using ReportingService.Business.Exceptions;
using ReportingService.Data.Repositories;

namespace ReportingService.Business.Services;

public class LeadOverallStatisticsService : ILeadOveralStatisticsService
{
    private readonly ILeadOverallStatisticsRepository _leadOverallStatisticRepository;

    public LeadOverallStatisticsService(ILeadOverallStatisticsRepository leadOverallStatisticRepository)
    {
        _leadOverallStatisticRepository = leadOverallStatisticRepository;
    }

    public Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, int daysCount)
    {
        var date = GetDateFromDaysCount(daysCount);
        ValidateDate(date);
        var result = _leadOverallStatisticRepository.GetLeadIdsWithNecessaryTransactionsCount(transactionsCount, date);
        return result;
    }

    public Task<List<int>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, int daysCount)
    {
        var date = GetDateFromDaysCount(daysCount);
        ValidateDate(date);
        var result = _leadOverallStatisticRepository.GetLeadsIdsWithNecessaryAmountDifference(amountDifference, date);
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