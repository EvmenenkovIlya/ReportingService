namespace ReportingService.DataCreator.Models
{
    public abstract class IModel
    {
        public abstract string ToCsvRow();
        public int LeadId { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public short TransactionType { get; set; }
    }
}
