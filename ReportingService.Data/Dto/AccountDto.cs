using IncredibleBackendContracts.Enums;

namespace ReportingService.Data.Dto;

public class AccountDto
{
    public int Id { get; set; }
    public Currency Currency { get; set; }
    public AccountStatus Status { get; set; }
    public int LeadId { get; set; }
}
