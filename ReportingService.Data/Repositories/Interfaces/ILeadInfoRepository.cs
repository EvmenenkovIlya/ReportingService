using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories
{
    public interface ILeadInfoRepository
    {
        Task AddLeadInfo(LeadInfoDto leadInfoDto);
        Task<List<int>> GetCelebrateIdsByDate(DateTime date);
        Task<List<LeadInfoDto>> GetAllLeadInfoDto();
        Task<LeadInfoDto> GetLeadInfoDtoByLeadId(int leadId);
        Task UpdateLeadInfo(LeadInfoDto leadInformationDto);
        Task DeleteLeadInfo(int leadId);
        Task UpdateLeadsStatus(List<int> vipIds);
    }
}