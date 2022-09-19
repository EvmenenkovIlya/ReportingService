﻿namespace ReportingService.Data.Dto;

public class StatisticsDto
{
    public DateTime DateStatistic { get; set; }
    public int RegularLeadsCount { get; set; }
    public int VipLeadsCount { get; set; }
    public int DeletedLeadsCount { get; set; }
    public int DeletedVipsCount { get; set; }
    public List<AccountsStatisticsDto> AccountsStatistics { get; set; }
}
