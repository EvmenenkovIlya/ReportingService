using IncredibleBackendContracts.Enums;

namespace ReportingService.API.Models;

public class AccountsStatisticResponse
{
    public Currency Currency { get; set; }
    public int ActiveAccountCount { get; set; }
    public int FrozenAccountCount { get; set; }
    public int DeletedAccountCount { get; set; }
}