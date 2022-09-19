namespace ReportingService.Business.Models;

public class Statistics
{
    public DateTime DateStatistic { get; set; }
    public int RegularLeadsCount { get; set; }
    public int VipLeadsCount { get; set; }
    public int DeletedLeadsCount { get; set; }
    public int DeletedVipsCount { get; set; }
    public List<AccountsStatistic> AccountsStatistic { get; set; }

}