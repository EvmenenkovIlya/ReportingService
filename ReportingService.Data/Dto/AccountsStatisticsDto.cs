using IncredibleBackendContracts.Enums;

namespace ReportingService.Data.Dto;
public class AccountsStatisticsDto
{
    public DateTime DateStatistic { get; set; }
    public Currency Currency { get; set; }
    public int ActiveAccountCount { get; set; }
    public int FrozenAccountCount { get; set; }
    public int DeletedAccountCount { get; set; }
}
