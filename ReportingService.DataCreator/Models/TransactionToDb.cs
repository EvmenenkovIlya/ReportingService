namespace ReportingService.DataCreator.Models;

public class TransactionToDb : IModel
{
    public long? Id { get; set; }
    public long TransactionId { get; set; }
    // public int AccountId {get; set:)
    //public DateTime Date { get; set; }
    public short TransactionType { get; set; }
    //public decimal Amount { get; set; }
    public short Currency { get; set; }
    public long? RecipientId { get; set; }
    public int? RecipientAccountId { get; set; }
    public decimal? RecipientAmount  { get; set; }
    public short? RecipientCurrency { get; set; }

    public TransactionToDb(TransactionFromCsv sender, TransactionFromCsv recipient)
    {
        AccountId = sender.AccountId;
        Date = sender.Date;
        TransactionId = sender.TransactionId;
        TransactionType = sender.TransactionType;
        Amount = sender.Amount;
        Currency = sender.Currency;
        RecipientId = recipient.TransactionId;
        RecipientAccountId = recipient.AccountId;
        RecipientAmount = recipient.Amount;
        RecipientCurrency = recipient.Currency;
    }

    public TransactionToDb(TransactionFromCsv sender)
    {
        AccountId = sender.AccountId;
        Date = sender.Date;
        TransactionId = sender.TransactionId;
        TransactionType = sender.TransactionType;
        Amount = sender.Amount;
        Currency = sender.Currency;
    }

    public override string ToCsvRow()
    {
        return $"{TransactionId};{AccountId};{Date};{TransactionType};{Amount};{Currency};{RecipientId};{RecipientAccountId};{RecipientAmount};{RecipientCurrency}";
    }
}
