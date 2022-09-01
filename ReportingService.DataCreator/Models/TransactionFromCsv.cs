namespace ReportingService.DataCreator.Models;

public class TransactionFromCsv : IModel, IComparable
{
    public long? Id { get; set; }
    public long TransactionId { get; set; }
    // accountId
    //public DateTime Date { get; set; }
    //public short TransactionType { get; set; }
    //public decimal Amount { get; set; }
    public short Currency { get; set; }

    public TransactionFromCsv(string line)
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
    }

    public override string ToCsvRow()
    {
        if (Date.Millisecond == 0)
            return $"{TransactionId};{AccountId};{Date.Year}-{Date.Month}-{Date.Day} {Date.Hour}:{Date.Minute}:{Date.Second}.0000000;{TransactionType};{Amount};{Currency}";
        else
            return $"{TransactionId};{AccountId};{Date.Year}-{Date.Month}-{Date.Day} {Date.TimeOfDay};{TransactionType};{Amount};{Currency}";
    }

    public int CompareTo(object trans)
    {

        // Storing incoming object in temp variable of 
        // current class type
        TransactionFromCsv transIn = trans as TransactionFromCsv;

        return this.TransactionType.CompareTo(transIn.TransactionType);

    }
}
