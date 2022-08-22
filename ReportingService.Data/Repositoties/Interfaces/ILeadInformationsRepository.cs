using ReportingService.Data.Dto;

namespace ReportingService.Data.Repositoties
{
    public interface ILeadInformationsRepository
    {
        string AddLeadInformation(LeadInformationDto leadInformationDto);
        List<int> GetAllBirthdayIds();
        List<LeadInformationDto> GetAllLeadInformationDto();
        LeadInformationDto GetLeadInformationDtoById(int id);
        LeadInformationDto UpdateLeadInformation(LeadInformationDto leadInformationDto);
    }
}