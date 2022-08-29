using ReportingService.Data.Enums;

namespace ReportingService.Business.Models;

public class Statistics
{
    public long Id { get; set; }
    public DateTime DateStatistics { get; set; }
    public Currency Сurrency { get; set; }
    public long ActiveAccountsCount { get; set; }
    public long AllAccountsCount { get; set; }
    public long ActiveLeadsCount { get; set; }
}