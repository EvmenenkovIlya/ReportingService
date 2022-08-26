﻿namespace ReportingService.Business.Models;

public class LeadStatistic
{
    public long Id { get; set; }
    public DateOnly DateStatistic { get; set; }
    public int LeadId { get; set; }
    public int TransactionCountForTwoMonth { get; set; }
    public decimal DepositsSum { get; set; }
    public decimal WithdrawSum { get; set; }
    public decimal TransferSum { get; set; }
    public long DepositCount { get; set; }
    public long WithdrawCount { get; set; }
    public long TransferCount { get; set; }
}