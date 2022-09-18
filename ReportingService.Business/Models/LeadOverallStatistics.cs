namespace ReportingService.Business.Models;

public class LeadOverallStatistics
{
    public long Id { get; set; }
    public DateTime DateStatistics { get; set; }
    public int LeadId { get; set; }
    public decimal DepositsSum { get; set; }
    public decimal WithdrawSum { get; set; }
    public decimal TransferSum { get; set; }
    public int DepositsCount { get; set; }
    public int WithdrawalsCount { get; set; }
    public int TransfersCount { get; set; }
}