

namespace ReportingService.Business.Services;

public interface ILeadOveralStatisticsService
{
    Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, int daysCount);
    Task<List<int>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, int daysCount);
}
