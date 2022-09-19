namespace ReportingService.Business.Models;

public class Statistics
{
    public DateTime DateStatistic { get; set; }
    public int RegularLeadsCount { get; set; }
    public int VipLeadsCount { get; set; }
    public int DeletedLeadsCount { get; set; }
    public int DeletedVipsCount { get; set; }
    public decimal DepositsSum { get; set; }
    public decimal WithdrawSum { get; set; }
    public decimal TransferSum { get; set; }
    public int DepositsCount { get; set; }
    public int WithdrawalsCount { get; set; }
    public int TransfersCount { get; set; }
    public List<AccountsStatistic> AccountsStatistic { get; set; }

}