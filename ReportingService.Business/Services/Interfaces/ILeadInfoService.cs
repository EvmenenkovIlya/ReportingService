using ReportingService.Business.Models;

namespace ReportingService.Business.Services;

public interface ILeadInfoService
{
    Task<List<int>> GetCelebrantsFromDateToNow(int daysCount);
    Task AddLeadInfo(LeadInfo leadInfo);
    Task<List<LeadInfo>> GetAllLeadInfo();
    Task<LeadInfo> GetLeadInfoByLeadId(int leadId);
    Task UpdateLeadInfo(UpdateLeadInfo leadInformation);
    Task DeleteLeadInfo(int leadId);
    Task UpdateLeadsStatus(List<int> vipIds);
}