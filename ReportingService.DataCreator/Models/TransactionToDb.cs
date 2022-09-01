using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace ReportingService.DataCreator.Models;

public class TransactionToDb : IModel
{
    public long? Id { get; set; }
    public long TransactionId { get; set; }
    // public int AccountId {get; set:)
    //public DateTime Date { get; set; }
    //public short TransactionType { get; set; }
    //public decimal Amount { get; set; }
    public short Currency { get; set; }
    public decimal? Rate { get; set; }
    public long? RecipientId { get; set; }
    public int? RecipientAccountId { get; set; }
    public decimal? RecipientAmount  { get; set; }
    public short? RecipientCurrency { get; set; }

    public TransactionToDb(string line)
    {
        string[] parts = line.Split(';');
        Id = null;
        TransactionId = Int64.Parse(parts[0]);
        AccountId = Int32.Parse(parts[1]);

        string[] dateParts = parts[2].Split('.');
        if (dateParts.Length == 1)
            Date = DateTime.Parse(dateParts[0]);
        else
            Date = DateTime.Parse(dateParts[0]).AddTicks(int.Parse(dateParts[1]));
        TransactionType = Int16.Parse(parts[3]);
        Amount = Decimal.Parse(parts[4]);
        Currency = Int16.Parse(parts[5]);
        if (parts.Length > 6)
        {
            Rate = Decimal.Parse(parts[6]);
            RecipientId = Int32.Parse(parts[7]);
            RecipientAccountId = Int32.Parse(parts[8]);
            RecipientAmount = Decimal.Parse(parts[9]);
            RecipientCurrency = Int16.Parse(parts[10]);
        }

    }

    public TransactionToDb(TransactionFromCsv sender, TransactionFromCsv recipient)
    {
        AccountId = sender.AccountId;
        Date = sender.Date;
        TransactionId = sender.TransactionId;
        TransactionType = sender.TransactionType;
        Amount = sender.Amount;
        Currency = sender.Currency;
        Rate = Decimal.Round(Math.Abs(recipient.Amount / sender.Amount), 4);
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
        if (Date.Millisecond == 0)
            return $"{TransactionId};{AccountId};{Date.Year}-{Date.Month}-{Date.Day} {Date.Hour}:{Date.Minute}:{Date.Second}.0000000;{TransactionType};{Amount};{Currency};{Rate};{RecipientId};{RecipientAccountId};{RecipientAmount};{RecipientCurrency}";
        else
        {
            return $"{TransactionId};{AccountId};{Date.Year}-{Date.Month}-{Date.Day} {Date.TimeOfDay};{TransactionType};{Amount};{Currency};{Rate};{RecipientId};{RecipientAccountId};{RecipientAmount};{RecipientCurrency}";
        }
    }
}
