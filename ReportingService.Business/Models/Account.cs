using ReportingService.Data.Enums;

namespace ReportingService.Business.Models;

public class Account
{
    public int Id { get; set; }
    public Currency Currency { get; set; }
    public Status Status { get; set; }
    public int LeadId { get; set; }
}