using IncredibleBackendContracts.Enums;

namespace ReportingService.Business.Models;

public class AccountsStatistic
{
    public Currency Currency { get; set; }
    public int ActiveAccountCount { get; set; }
    public int FrozenAccountCount { get; set; }
    public int DeletedAccountCount { get; set; }
}

