using ReportingService.Data.Dto;
using System.Data;

namespace ReportingService.Data.Repositories;

public interface ILeadOverallStatisticsRepository
{
    Task AddLeadStatistic(List<LeadOverallStatisticsDto> statistics);
    Task<List<LeadOverallStatisticsDto>> GetAllLeadStatisticDto();
    Task<LeadOverallStatisticsDto> GetLeadStatisticDtoById(int id);
    Task UpdateLeadStatisticDto(LeadOverallStatisticsDto leadStatisticDto);
    Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, DateTime date);
    Task<List<int>> GetLeadsIdsWithNecessaryAmountDifference(decimal amountDifference, DateTime date);
    Task<List<LeadOverallStatisticsDto>> GetOverallStatisiticsByDate(DateTime date);
}