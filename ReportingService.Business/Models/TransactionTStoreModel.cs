﻿using IncredibleBackendContracts.Enums;

namespace ReportingService.Business.Models;

public class TransactionTStoreModel
{
    public long Id { get; set; }
    public long AccountId { get; set; }
    public DateTime Date { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }
}