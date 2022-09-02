using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface ILeadOverallStatisticsRepository
{
    Task AddLeadStatistic(LeadOverallStatisticsDto leadStatisticDto);
    Task<List<LeadOverallStatisticsDto>> GetAllLeadStatisticDto();
    Task<LeadOverallStatisticsDto> GetLeadStatisticDtoById(int id);
    Task UpdateLeadStatisticDto(LeadOverallStatisticsDto leadStatisticDto);
    Task<List<int>> GetLeadIdsWithNecessaryTransactionsCount(int transactionsCount, DateTime date);
    Task<List<int>> GetLeadsIdsWithDifferenceOfMore13000();
}