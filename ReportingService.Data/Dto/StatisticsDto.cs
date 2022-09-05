
using ReportingService.Data.Enums;

namespace ReportingService.Data.Dto;

public class StatisticsDto
{
    public long Id { get; set; }
    public DateOnly DateStatistic { get; set; }
    public Currency Currency { get; set; }
    public int ActiveAccountCount { get; set; }
    public int AllAccountCount { get; set; }
    public int ActiveLeadCount { get; set; }
}
