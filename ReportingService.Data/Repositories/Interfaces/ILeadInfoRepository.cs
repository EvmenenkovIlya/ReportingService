using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories
{
    public interface ILeadInfoRepository
    {
        Task<string> AddLeadInformation(LeadInfoDto leadInformationDto);
        Task<List<int>> GetCelebrateIdsByDate(DateTime date);
        Task<List<LeadInfoDto>> GetAllLeadInformationDto();
        Task<LeadInfoDto> GetLeadInformationDtoById(int id);
        Task<LeadInfoDto> UpdateLeadInformation(LeadInfoDto leadInformationDto);
    }
}