using IncredibleBackendContracts.Enums;

namespace ReportingService.Data.Dto;

public class AccountDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public TradingCurrency Currency { get; set; }
    public AccountStatus Status { get; set; }
    public int LeadId { get; set; }
}
