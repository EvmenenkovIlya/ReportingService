

namespace ReportingService.Business.Services;

public interface ILeadOverallStatisticsService
{
    Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, int daysCount);
    Task<List<int>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, int daysCount);
    Task Execute();
    Task CreateLeadOverallsStatistics();
}
