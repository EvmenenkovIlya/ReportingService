using IncredibleBackendContracts.Enums;

namespace ReportingService.Business.Models;

public class Account
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public TradingCurrency Currency { get; set; }
    public AccountStatus Status { get; set; }
    public int LeadId { get; set; }
}