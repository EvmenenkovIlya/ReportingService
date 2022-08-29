using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface ILeadStatisticsRepository
{
    Task AddLeadStatistic(LeadStatisticDto leadStatisticDto);
    Task<List<LeadStatisticDto>> GetAllLeadStatisticDto();
    Task<LeadStatisticDto> GetLeadStatisticDtoById(int id);
    Task UpdateLeadStatisticDto(LeadStatisticDto leadStatisticDto);
    Task<List<int>> GetLeadsIdsWith42Transactions();
    Task<List<int>> GetLeadsIdsWithDifferenceOfMore13000();
}