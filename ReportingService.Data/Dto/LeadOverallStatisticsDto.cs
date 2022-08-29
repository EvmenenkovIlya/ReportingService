namespace ReportingService.Data.Dto;

public class LeadOverallStatisticsDto
{
    public long Id { get; set; }
    public DateOnly DateStatistics { get; set; }
    public int LeadId { get; set; }
    public int TransactionCountForTwoMonth { get; set; }
    public decimal DepositsSum { get; set; }
    public decimal WithdrawSum { get; set; }
    public decimal TransferSum { get; set; }
    public int DepositsCount { get; set; }
    public int WithdrawalsCount { get; set; }
    public int TransfersCount { get; set; }
}
