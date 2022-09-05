using IncredibleBackendContracts.Enums;

namespace ReportingService.Business.Models;
public class Transaction
{
    public long Id { get; set; }
    public long AccountId { get; set; }
    public DateTime Date { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public Currency Currency { get; set; }
    public decimal Rate { get; set; }
    public int? RecipientId { get; set; }
    public int? RecipientAccountId { get; set; }
    public decimal? RecipientAmount { get; set; }
    public Currency? RecipientCurrency { get; set; }
}
