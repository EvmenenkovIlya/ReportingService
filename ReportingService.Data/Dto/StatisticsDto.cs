namespace ReportingService.Data.Dto;

public class StatisticsDto
{
    public long Id { get; set; }
    public DateOnly DateStatistic { get; set; }
    public int AllLeadsCount { get; set; }
    public int VipLeadsCount { get; set; }
    public int DeletedLeadsCount { get; set; }
    public int DeletedVipsCount { get; set; }
}
