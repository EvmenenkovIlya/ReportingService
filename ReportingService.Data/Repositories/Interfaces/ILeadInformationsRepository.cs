using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositories
{
    public interface ILeadInformationsRepository
    {
        Task<string> AddLeadInformation(LeadInformationDto leadInformationDto);
        Task<List<int>> GetAllBirthdayIds();
        Task<List<LeadInformationDto>> GetAllLeadInformationDto();
        Task<LeadInformationDto> GetLeadInformationDtoById(int id);
        Task<LeadInformationDto> UpdateLeadInformation(LeadInformationDto leadInformationDto);
    }
}