using ReportingService.Data.Dto;
using System.Data;

namespace ReportingService.Data.Repositories;

public interface ILeadOverallStatisticsRepository
{
    Task<List<LeadOverallStatisticsDto>> GetAllLeadStatisticDto();
    Task<LeadOverallStatisticsDto> GetLeadStatisticDtoById(int id);
    Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, DateTime date);
    Task<List<int>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, DateTime date);
    Task GetOverallStatisticsByDate(DateTime date);
}