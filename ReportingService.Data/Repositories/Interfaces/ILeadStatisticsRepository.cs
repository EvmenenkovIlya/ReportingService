using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories;

public interface ILeadStatisticsRepository
{
    void AddLeadStatistic(LeadStatisticDto leadStatisticDto);
    List<LeadStatisticDto> GetAllLeadStatisticDto();
    LeadStatisticDto GetLeadStatisticDtoById(int id);
    void UpdateLeadStatisticDto(LeadStatisticDto leadStatisticDto);
}