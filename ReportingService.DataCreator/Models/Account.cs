namespace ReportingService.DataCreator.Models;

public class Account: IModel
{
    public int AccountId { get; set; }
    public int Currency { get; set; }
    public int Status { get; set; }
    public int LeadId { get; set; }
    public bool IsDeleted { get; set; }

    public Account(string line)
    {
        string[] parts = line.Split(';');
        AccountId = Int32.Parse(parts[0]);
        Currency = Int32.Parse(parts[1]);
        Status = Int32.Parse(parts[2]);
        LeadId = Int32.Parse(parts[3]);
        //IsDeleted = Boolean.Parse(parts[4]) ;
    }

    public override string ToCsvRow()
    {
        if (IsDeleted)
            Status = 2;
        return $"{AccountId};{Currency};{Status};{LeadId}";
    }
}
