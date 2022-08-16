
using ReportingService.Data.Enums;

namespace ReportingService.Data.Dto;

public class AccountDto
{
    public long Id { get; set; }
    public Currency Currency { get; set; }
    public Status Status { get; set; }
    public long LeadId { get; set; }
}
