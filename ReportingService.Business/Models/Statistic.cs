using ReportingService.Data.Enums;

namespace ReportingService.Business.Models;

public class Statistic
{
    public long Id { get; set; }
    public DateOnly DateStatistic { get; set; }
    public Currency Сurrency { get; set; }
    public long ActiveAccountCount { get; set; }
    public long AllAccountCount { get; set; }
    public long ActiveLeadCount { get; set; }
}