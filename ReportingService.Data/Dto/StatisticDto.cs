
namespace ReportingService.Data.Dto;

public class StatisticDto
{
    public long Id { get; set; }
    public DateOnly DateStatistic { get; set; }
    public long DepositCount { get; set; }
    public long WithdrawCount { get; set; }
    public long TransferCount { get; set; }
    public decimal DepositSum { get; set; }
    public decimal WithdrawSum { get; set; }
    public decimal TransferSum { get; set; }
    public long ActiveAccountCount { get; set; }
    public long AllAccountCount { get; set; }
    public long ActiveLeadCount { get; set; }

}
