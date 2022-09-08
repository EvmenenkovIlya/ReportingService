

namespace ReportingService.Business.Services;

public interface ILeadOverallStatisticsService
{
    Task Execute();
    Task CreateLeadsOverallStatistics();
    Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, int daysCount);
    Task<List<int>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, int daysCount);
}
