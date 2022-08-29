using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface ILeadOverallStatisticsRepository
{
    Task AddLeadStatistic(LeadOverallStatisticsDto leadStatisticDto);
    Task<List<LeadOverallStatisticsDto>> GetAllLeadStatisticDto();
    Task<LeadOverallStatisticsDto> GetLeadStatisticDtoById(int id);
    Task UpdateLeadStatisticDto(LeadOverallStatisticsDto leadStatisticDto);
    Task<List<int>> GetLeadsIdsWith42Transactions();
    Task<List<int>> GetLeadsIdsWithDifferenceOfMore13000();
}