namespace ReportingService.DataCreator.Models;

public class TransactionFromCsv : IModel
{
    public long? Id { get; set; }
    public long TransactionId { get; set; }
    // accountId
    //public DateTime Date { get; set; }
    public short TransactionType { get; set; }
    //public decimal Amount { get; set; }
    public short Currency { get; set; }

    public TransactionFromCsv(string line)
    {
        string[] parts = line.Split(';');
        Id = null;
        TransactionId = Int64.Parse(parts[0]);
        AccountId = Int32.Parse(parts[1]);
        Date = DateTime.Parse(parts[2]);
        TransactionType = Int16.Parse(parts[3]);
        Amount = Decimal.Parse(parts[4]);
        Currency = Int16.Parse(parts[5]);
    }

    public override string ToCsvRow()
    {
        return $"{TransactionId};{AccountId};{Date};{TransactionType};{Amount};{Currency}";
    }
}
